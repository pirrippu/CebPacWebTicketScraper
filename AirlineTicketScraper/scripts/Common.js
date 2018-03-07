$(document).ready(function () {
    //INITIALIZE MATERIALIZE CSS COMPONENTS
    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15 // Creates a dropdown of 15 years to control year
    });
    $('select').material_select();

    $('#destinationSelect').change(function () {
        var selectValue = $('#destinationSelect').val();
        $('#ToFldHidden').val(selectValue);
    });

    $('#myTable').DataTable();
});