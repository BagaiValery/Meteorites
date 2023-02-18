$(document).ready(function () {
    // get the table body
    var tableBody = $('#meteoriteTable tbody');

    // get the search input
    var nameSearchInput = $('#name-search');

    // update the table with the search results when the user types in the search box
    nameSearchInput.on('keyup', function () {
        var nameFilter = nameSearchInput.val();
        $.get('@Url.Action("SearchByName", "Meteorite")', { nameFilter: nameFilter }, function (data) {
            // clear the existing table rows
            tableBody.empty();

            // add the new rows to the table
            $.each(data, function (index, meteorite) {
                var row = '<tr><td>' + meteorite.name + '</td><td>' + meteorite.year + '</td><td>' + meteorite.mass + '</td></tr>';
                tableBody.append(row);
            });
        });
    });
});