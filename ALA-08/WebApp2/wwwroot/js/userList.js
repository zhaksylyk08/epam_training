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

    $(".addUser").click(function () {
        $(".addUserContainer").css("display", "block");
    });

    $(".addUserContainer").find(".add-new-user-btn").click(function (e) {
        e.preventDefault();

        let url = "/create-user";
        let formData = $(".addUserContainer").find(".user-form");
        $.post(url, formData.serialize()).done(function (answerFromServer) {
            if (answerFromServer)
            {
                $(".addUserContainer").css("display", "none");
                alert("New User is added");
            }
        });
    });
});