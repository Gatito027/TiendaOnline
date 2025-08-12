$(document).ready(function () {
    $(#btnGuardar).click(function (e) {
        e.preventDefault();
        var fileInput = $("#txtFile")[0];
        var files = fileInput.files;
        if (files.length === 0) {
            alert("Por favor, selecciona una imagen antes de subir.");
            return;
        }
        var file = Array.from(files).find(f => f.type.startsWith("image/"));
        if (!file) {
            alert("Solo se permiten archivos de imagen.");
            return;
        }
        var formData = new FormData();
        formData.append("archivos", file);
        var userId = 123;
        $.ajax({
            url: `/api/archivos/${userId}`,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                alert("Archivo subido correctamente.");
            },
            error: function (xhr, status, error) {
                alert("Error al subir el archivo: " + xhr.responseText);
            }
        });
    });
});