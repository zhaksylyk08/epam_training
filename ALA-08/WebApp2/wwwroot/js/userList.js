$(document).ready(function () {
    $(".remove").click(function () {
        let button = $(this);
        let user = $(this).closest(".user");
        let userId = user.data("id");
        let url = urls.userDelete + "?id=" + userId;

        $.get(url).done(function (answerFromServer) {
            if (answerFromServer) {
                user.remove();
            }
        });
    });
});