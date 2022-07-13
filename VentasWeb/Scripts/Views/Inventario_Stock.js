$(document).ready(function () {
    activarMenu("Dashboard");

    //OBTENER Categorias
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerCategorias,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data)

            $("#cboTienda").LoadingOverlay("hide");
            $("#cboTienda").html("");

            $("<option>").attr({ "value": 0 }).text("Seleccionar todas").appendTo("#cboTienda");
            if (data.data != null)
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdCategoria }).text(item.Descripcion).appendTo("#cboTienda");
                    }
                })
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $("#cboTienda").LoadingOverlay("show");
        },
    });
    //OBTENER Categorias
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerCategorias,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data)

            $("#cboTienda2").LoadingOverlay("hide");
            $("#cboTienda2").html("");

            $("<option>").attr({ "value": 0 }).text("Seleccionar todas").appendTo("#cboTienda2");
            if (data.data != null)
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdCategoria }).text(item.Descripcion).appendTo("#cboTienda2");
                    }
                })
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $("#cboTienda2").LoadingOverlay("show");
        },
    });

})


$('#btnBuscar').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerStockProducto + "?idcategoria=" + $("#cboTienda").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $("#tbReporte tbody").html("");


                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td>").text(row["NombreTienda"]),
                        $("<td>").text(row["CodigoProducto"]),
                        $("<td>").text(row["NombreProducto"]),
                        $("<td>").text(row["DescripcionProducto"]),
                        $("<td>").text(row["StockenTienda"]),

                    ).appendTo("#tbReporte tbody");

                })

            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });

})


function printData() {

    if ($('#tbReporte tbody tr').length == 0) {
        swal("Mensaje", "No existen datos para imprimir", "warning")
        return;
    }

    var divToPrint = document.getElementById("tbReporte");

    var style = "<style>";
    style = style + "table {width: 100%;font: 17px Calibri;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "</style>";

    newWin = window.open("");


    newWin.document.write(style);
    newWin.document.write("<h3>Reporte de productos por tienda</h3>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}
function printData2() {

    if ($('#tbReporte tbody tr').length == 0) {
        swal("Mensaje", "No existen datos para imprimir", "warning")
        return;
    }

    var divToPrint = document.getElementById("tbReporte");

    var style = "<style>";
    style = style + "table {width: 100%;font: 17px Calibri;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "</style>";

    newWin = window.open("");


    newWin.document.write(style);
    newWin.document.write("<h3>Reporte stock de productos</h3>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}
function printData3() {

    if ($('#tbReporteCaducidad tbody tr').length == 0) {
        swal("Mensaje", "No existen datos para imprimir", "warning")
        return;
    }

    var divToPrint = document.getElementById("tbReporteCaducidad");

    var style = "<style>";
    style = style + "table {width: 100%;font: 17px Calibri;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "</style>";

    newWin = window.open("");


    newWin.document.write(style);
    newWin.document.write("<h3>Reporte de caducidad de productos</h3>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}

$('#btnBuscarCaducidad').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerProductoCaducidad + "?idcategoria=" + $("#cboTienda2").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $("#tbReporteCaducidad tbody").html("");


                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td>").text(row["NombreTienda"]),
                        $("<td>").text(row["CodigoProducto"]),
                        $("<td>").text(row["NombreProducto"]),
                        $("<td>").text(row["DescripcionProducto"]),
                        $("<td>").text(row["FechaVencimiento"]),

                    ).appendTo("#tbReporteCaducidad tbody");

                })

            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });

})