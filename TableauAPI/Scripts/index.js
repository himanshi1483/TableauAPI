$(document).ready(function () {
    $("#tabs").show();
    $("#tabs").tabs();
    $("#vizContainer").height(window.innerHeight - 200)
    $("#vizContainer2").height(window.innerHeight)
    $("#dataContainer").height(window.innerHeight - 250)
    // $("#tableauURL").change(function () {
    //     initViz();
    // });
    $("#menu").change(function () {
        fetchSheetData();
    });
    initViz2();
    initViz();
    // initViz2();
});

function initViz() {
    $("#vizContainer").empty();
    $("#dataContainer").empty();
    $("#menu").empty();
    $("#vizContainer").append("<div id='tableau_visualization'></div>");
    var containerDiv = document.getElementById("tableau_visualization"),
        // url = $("#tableauURL").val(), // "https://public.tableau.com/views/hierarchy_demo/demo",
        //this url shows how it works with a dashboard. Comment the above and uncomment below to switch.
        url = "https://us-west-2b.online.tableau.com/t/proximous/views/SentimentAnalysisV1_0/AlexaData2?iframeSizedToWindow=true&:embed=y&:showAppBanner=false&:display_count=no&:showVizHome=no",
        options = {
            hideTabs: true,
            hideToolbar: true,
            onFirstInteractive: function () {
                workbook = viz.getWorkbook();
                getVizData();
            }
        };
    viz = new tableau.Viz(containerDiv, url, options);

}
function initViz2() {
    $("#vizContainer2").empty();

    $("#vizContainer2").append("<div id='tableau_visualization2'></div>");
    var containerDiv2 = document.getElementById("tableau_visualization2"),
        // url = $("#tableauURL").val(), // "https://public.tableau.com/views/hierarchy_demo/demo",
        //this url shows how it works with a dashboard. Comment the above and uncomment below to switch.
        url = "https://us-west-2b.online.tableau.com/t/proximous/views/SentimentAnalysisV1_0/SentimentAnalysisDashboard?iframeSizedToWindow=true&:embed=y&:showAppBanner=false&:refresh=true&:display_count=no&:showVizHome=no",
        options = {
            hideTabs: true,
            hideToolbar: true,
            // onFirstInteractive: function () {
            //     workbook = viz.getWorkbook();
            //     getVizData();
            // }
        };
    viz = new tableau.Viz(containerDiv2, url, options);
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
            });
        }
        //if active sheet is a dashboard get data from a specified sheet
    } else {
        // alert("SheetType = " + sheet.getSheetType());
        // debugger;
        worksheetArray = viz.getWorkbook().getActiveSheet().getWorksheets();
        for (var i = 0; i < worksheetArray.length; i++) {
            sheet = worksheetArray[i];
            if (sheet.getSheetType() == 'worksheet') {
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
        if (sheet.getSheetType() == 'worksheet' && sheet.getName() === $("#menu").val()) {
            var sheetName = sheet.getName();
            sheet.getUnderlyingDataAsync(options).then(function (t) {
                prepareTable(sheetName, t);
            });
        }
    }
}

//restructure the data and build something with it
function prepareTable(name, table) {
    var rowNum = 100;
    //the data returned from the tableau API
    var columns = table.getColumns();
    var data = table.getData();
    //console.log(data);
    //console.log(data[0]);

    // //convert to field:values convention
    function reduceToObjects(cols, data) {
        var fieldNameMap = $.map(cols, function (col) {
            return col.getFieldName();
        });
        var dataToReturn = $.map(data, function (d) {
            return d.reduce(function (memo, value, idx) {
                memo[fieldNameMap[idx]] = value.value;
                return memo;
            }, {});
        });
        return dataToReturn;
    }


    var niceData = reduceToObjects(columns, data);
    //OutPut JSON.stringify(niceData)
    console.log(JSON.stringify(niceData));
    // createItem(niceData);

    var table = $("<table>");
    var tr = $("<tr>")
    columns.forEach(function (col, i) {
        var th = $("<th>")
        th.text(col.getFieldName());
        tr.append(th);
    });
    table.append(tr);

    data.every(function (row, i) {
        if (i >= rowNum) {
            return false;
        }
        tr = $("<tr>")
        row.forEach(function (col) {
            var td = $("<td>")
            td.text(col.formattedValue);
            tr.append(td);
        });
        table.append(tr);
        return true;
    });
    var tableContainer = $("<div class='tableContainer'>");
    var tableHeading = $("<p>" + (data.length > rowNum ? " (showing only " + rowNum + "/" + data.length + " rows)" : " (showing " + data.length + " rows)") + "</p>")
    tableContainer.append(tableHeading);
    tableContainer.append(table);
    $('#dataContainer').append(tableContainer);
}