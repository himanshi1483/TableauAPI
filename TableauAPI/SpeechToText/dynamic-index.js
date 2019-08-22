$(document).ready(function () {

    window.SpeechRecognition = window.webkitSpeechRecognition || window.SpeechRecognition;
    if ('SpeechRecognition' in window) {
        // speech recognition API supported
        console.log("Supported");

    } else {
        // speech recognition API not supported
        console.log("Not Supported");
    }
   // $("#tabs").show();
   // $("#tabs").tabs();
    $("#vizContainer").height(window.innerHeight - 200);
    $("#dataContainer").height(window.innerHeight - 250);
    $("#tableauURL").change(function () {
        initViz();
    });
    $("#menu").change(function () {
        //console.log(data[0]);

        fetchSheetData();
    });

});

function initViz() {
    $("#vizContainer").empty();
    $("#dataContainer").empty();
    $("#menu").empty();
    $("#vizContainer").append("<div id='tableau_visualization'></div>");
    var containerDiv = document.getElementById("tableau_visualization"),
        url = $("#tableauURL").val(), // "https://public.tableau.com/views/hierarchy_demo/demo",
        //this url shows how it works with a dashboard. Comment the above and uncomment below to switch.
        //url = "https://public.tableau.com/views/hierarchy_demo/hierarchy_demo",
        options = {
            hideTabs: true,
            hideToolbar: true,
            onFirstInteractive: function () {
                workbook = viz.getWorkbook();
                $("#dashboardTitle").text(workbook.getName());
                $("#dashboardTitle").css('display', 'block');
                $("#dashboardTitle").css('font-weight', 'bold');
                getVizData();
                //console.log(workbook.getColumns());

            }
        };
    viz = new tableau.Viz(containerDiv, url, options);
}

function savetoDB(_url) {
    var dbClient = new awsSdk.DynamoDB.DocumentClient();
    var url = _url;
    var params = {
        TableName: "DashboardData",
        Key: {
            "Url": string.empty,
        },
        UpdateExpression: "set Url = :newUrl",
        ExpressionAttributeValues: {
            ":newUrl": url
        }
    };
    dbClient.update(params, (() => {
        this.emit(':ask', 'is this your dashboard');
    }));
}



//when viz is loaded (onFirstInteractive), request data
function getVizData() {
    options = {
        maxRows: 0, // Max rows to return. Use 0 to return all rows
        ignoreAliases: false,
        ignoreSelection: true,
        includeAllColumns: false
    };

    sheet = viz.getWorkbook().getActiveSheet();

    //if active tab is a worksheet, get data from that sheet
    if (sheet.getSheetType() === 'worksheet') {
        $('#menu').append('<option>' + sheet.getName() + '</option>');
        if ($('#menu option').length === 1) {
            sheet.getUnderlyingDataAsync(options).then(function (t) {
                prepareTable(sheet.getName(), t);
                // buildMenu(t);
            });
        }
        //if active sheet is a dashboard get data from a specified sheet
    } else {
        // alert("SheetType = " + sheet.getSheetType());
        // debugger;
        worksheetArray = viz.getWorkbook().getActiveSheet().getWorksheets();
        for (var i = 0; i < worksheetArray.length; i++) {
            sheet = worksheetArray[i];
            if (sheet.getSheetType() === 'worksheet') {
                $('#menu').append('<option>' + sheet.getName() + '</option>');
            }
        }
        fetchSheetData();
    }
}

function fetchSheetData() {
    $('#dataContainer').empty();

    worksheetArray = viz.getWorkbook().getActiveSheet().getWorksheets();

    for (var i = 0; i < worksheetArray.length; i++) {
        sheet = worksheetArray[i];
        if (sheet.getSheetType() === 'worksheet' && sheet.getName() === $("#menu").val()) {
            var sheetName = sheet.getName();
            // console.log(sheetName);
            sheet.getUnderlyingDataAsync(options).then(function (t) {
                var ul = document.getElementById("dashboardCols");
                var lis = ul.children;

                const li_count =lis.length;
                if (li_count > 0) {
                    for (let index = 0; index < li_count; index++) {     
                        ul.removeChild(lis[0]);                    
                    }               
                }
                prepareTable(sheetName, t);
            });
        }

    }
}

//restructure the data and build something with it
function prepareTable(name, table) {

    var rowNum = 50;
    //the data returned from the tableau API
    var columns = table.getColumns();
    var data = table.getData();
    // console.log(columns[0]);
    var arr = [];
    var dataArr = [];
    $('<legend style="font-size:14px;" class="btn btn-default">Dimensions and Metrics</legend>').appendTo('#dashboardCols');
    // //convert to field:values convention
    function reduceToObjects(cols, data) {
        var fieldNameMap = $.map(cols, function (col) {

            var colsdata = col.getFieldName();
            arr.push(colsdata);
          
            var li = $('<li class="list-inline-item btn btn-info" style="margin-bottom:10px">' + colsdata + '</li>').appendTo('#dashboardCols');
            return col.getFieldName();
        });
        localStorage.setItem("Fields", arr);
        var dataToReturn = $.map(data, function (d) {
            return d.reduce(function (memo, value, idx) {
                memo[fieldNameMap[idx]] = value.value;
                dataArr.push(memo[fieldNameMap[idx]]);
            
                return memo;
            }, {});

        });
        localStorage.setItem("FieldData", dataArr);
        return dataToReturn;
    }


    var niceData = reduceToObjects(columns, data);
    //console.log(JSON.stringify(niceData));
    // createItem(niceData);
    if (niceData !== null) {
        $.ajax({
            type: "POST",
            url: "@Url.Action("DynamicDashboard")",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { "data": d },
            success: function (d) {
                if (d.success === true)
                    window.location.reload();
                else {
                    alert("error");
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("error:" + textStatus);
            }
        });
    }

    var table1 = $("<table>");
    var tr = $("<tr>");
    columns.forEach(function (col, i) {
        var th = $("<th>");
        th.text(col.getFieldName());
        tr.append(th);
    });
    table1.append(tr);

    data.every(function (row, i) {
        if (i >= rowNum) {
            return false;
        }
        tr = $("<tr>");
        row.forEach(function (col) {
            var td = $("<td>");
            td.text(col.formattedValue);
            tr.append(td);
        });
        table1.append(tr);
        return true;
    });
    var tableContainer = $("<div class='tableContainer'>");
    var tableHeading = $("<p>" + (data.length > rowNum ? " (showing only " + rowNum + "/" + data.length + " rows)" : " (showing " + data.length + " rows)") + "</p>")
    tableContainer.append(tableHeading);
    tableContainer.append(table1);
    $('#dataContainer').append(tableContainer);
}


//restructure the data and build something with it
function buildMenu(table) {
    var rowNum = 50;
    //the data returned from the tableau API
    var columns = table.getColumns();
    var data = table.getData();

    //convert to field:values convention
    function reduceToObjects(cols, data) {
        var fieldNameMap = $.map(cols, function (col) { return col.getFieldName(); });
        var dataToReturn = $.map(data, function (d) {
            return d.reduce(function (memo, value, idx) {
                memo[fieldNameMap[idx]] = value.value; return memo;
            }, {});
        });
        return dataToReturn;
    }

    var niceData = reduceToObjects(columns, data);

    //create nested tree structure
    var menuTree = d3.nest()
        .key(function (d) { return d.Level1; }).sortKeys(d3.ascending)
        .key(function (d) { return d.Level2; }).sortKeys(d3.ascending)
        .key(function (d) { return d.Level3; }).sortKeys(d3.ascending)
        .rollup(function (leaves) { return leaves.length; })
        .entries(niceData);

    //D3 layout menu list
    var menu = d3.select('#menuTree').selectAll('ul')
        .data(menuTree)
        .enter()
        .append('ul')

    //append list items
    function writeMenu(parentList) {

        var item = parentList
            .filter(function (d) { return d.key !== "%null%"; })
            .append('li')
            .text(function (d) { return d.key; })
            .classed("collapsed", true);
        console.log(item);

        var children = parentList.selectAll('ul')
            .data(function (d) { return d.values })
            .enter().append('ul');

        if (!children.empty()) {
            writeMenu(children);
        }
    }
    writeMenu(menu);

    //init collapible functions
    $('ul>li').siblings("ul").toggle();
    $('ul').not(':has(li)').remove(); //removes empty children with Null values. not a perfect approach, but easier for this demo
    $('ul>li').click(function () {

        //expand if it has children
        if ($(this).siblings('ul').length) {
            $(this).toggleClass("collapsed");
            $(this).siblings("ul").slideToggle(300);
        }

        //apply parameter to change the viz
        // var depth = $(this).parents("ul").length;
        // if ($(this).text()=="Show Top Level") {
        // 	workbook.changeParameterValueAsync("nameInput","");
        // 	workbook.changeParameterValueAsync("levelInput",0);
        // } else {
        // 	workbook.changeParameterValueAsync("nameInput",$(this).text());
        // 	workbook.changeParameterValueAsync("levelInput",depth);
        // }
    });
}

