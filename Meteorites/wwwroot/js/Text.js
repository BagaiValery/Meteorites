$(document).ready(function () {
    TextBox();
    Droplists();
});




function GetClasses() {
    $.ajax({
        url: '/Meteorite/GetDistinctClasses',
        success: function (data) {
            $.each(data, function (mc, mclass) {
                console.log(mclass.recclass);
                $('#meteorite-class').append('<Option value=' + mclass.recclass + '>' + mclass.recclass + '</Option>');
            });
        }
    });
}

function TextBox() {

    // get the search input
    var nameSearchInput = $('#name-search');
            nameSearchInput.on('keyup', function () {
                var nameFilter = nameSearchInput.val();
                $.get('/Meteorite/SearchByName', { nameFilter: nameFilter }, function (data) {
                    // clear the existing table rows
                    $('#meteoriteTable tbody').empty();

                    // add the new rows to the table
                    addMeteoritesToTable(data);
                });
            });
}

function Droplists() {
    // Cache the dropdowns for start and end years
    var $startYearDropdown = $('#start-year');
    var $endYearDropdown = $('#end-year');
    var $meteoriteClassDropdown = $('#meteorite-class');

    // Attach an event listener to both dropdowns
    $startYearDropdown.add($endYearDropdown).add($meteoriteClassDropdown).on('change', function () {
        // Get the selected start and end years
        var startYear = $startYearDropdown.val();
        var endYear = $endYearDropdown.val();
        var meteorClass = $meteoriteClassDropdown.val();
        // Send an AJAX request to get the filtered meteorites
        $.get('/Meteorite/GetMeteoritesByYearRange', { startYear: startYear, endYear: endYear, meteorClass: meteorClass }, function (data) {
            // Clear the existing rows from the table
            $('#meteoriteTable tbody').empty();

            // add the new rows to the table
            addMeteoritesToTable(data);

        });
    });
}




function addMeteoritesToTable(data) {
    $.each(data, function (index, meteorite) {
        $('#meteoriteTable tbody').append(
            '<tr>' +
            '<td>' + meteorite.name + '</td>' +
            '<td>' + meteorite.nametype + '</td>' +
            '<td>' + meteorite.recclass + '</td>' +
            '<td>' + meteorite.mass + '</td>' +
            '<td>' + meteorite.fall + '</td>' +
            '<td>' + meteorite.year + '</td>' +
            '<td>' + meteorite.reclat + '</td>' +
            '<td>' + meteorite.reclong + '</td>' +
            '<td>' + meteorite.computed_region_cbhk_fwbd + '</td>' +
            '<td>' + meteorite.computed_region_nnqa_25f4 + '</td>' +
            '</tr>'
        );
    });
}