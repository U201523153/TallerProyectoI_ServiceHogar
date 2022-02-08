$(function () {
    $('#FECHANAC').datepicker({
        format: 'dd/mm/yyyy',
        firstDay: 1,
        autoclose: true,
        todayBtn: true,
        pickerPosition: "bottom-lef",
        language: 'es',
        weekStart: 1,
        todayHighlight: 1
    });
});