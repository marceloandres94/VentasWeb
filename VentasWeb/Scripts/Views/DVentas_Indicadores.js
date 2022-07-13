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
})


$('#btnBuscar').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerVentaBeneficio + "?idcategoria=" + $("#cboTienda").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $("#tbReporte tbody").html("");


                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td>").text(row["Nombre"]),
                        $("<td>").text(row["Cantidad"]),
                        $("<td>").text(row["PrecioUnidadVenta"]),
                        $("<td>").text(row["ImporteTotal"]),
                        $("<td>").text(row["Ganancia"]),

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
    newWin.document.write("<h3>Reporte de ganancia de productos</h3>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}

$('#btnBuscar').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerBeneficioCat + "?idcategoria=" + $("#cboTienda").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data != undefined && data != null) {

                $("#txtBeneficioBruto").html("");


                $.each(data, function (i, row) {

                    $("#txtBeneficioBruto").append(

                        $("#txtBeneficioBruto").val(row["BeneficioBruto"]),
                    ).appendTo("#txtBeneficioBruto");
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