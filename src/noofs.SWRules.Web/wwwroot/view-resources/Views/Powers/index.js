(function () {
    $(function () {
        $('.details-game-system').click(function (e) {
            var systemId = $(this).attr("data-game-system-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'GameSystems/DetailsGameSystemModal?gameSystemId=' + systemId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#GameSystemDetailsModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });
    });
})();