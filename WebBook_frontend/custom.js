function logout() {
    $.session.clear();
    $(location).attr('href', 'login.html');
}






function filtreoku(selection = "") {

    $.ajax({
        url: 'http://localhost:62101/api/filter/add-filter',
        type: 'POST',

        dataType: 'json',
        data: JSON.stringify({
            Selection: selection,
        }),
        contentType: 'application/json; charset=utf-8',

        success: function (selection) { },
        error: function (error) { }
    });



}


function siralamaoku(selectionSort = "") {

    $.ajax({
        url: 'http://localhost:62101/api/sort/add-sort',
        type: 'POST',

        dataType: 'json',
        data: JSON.stringify({
            SelectionSort: selectionSort,
        }),
        contentType: 'application/json; charset=utf-8',

        success: function (selection) {},
        error: function (error) { }
    });




}

function likeBtn(id, book = "") {
    if (book != "") {
        $.ajax({
            url: 'http://localhost:62101/api/like/add-like',
            type: 'POST',
            
            dataType: 'json',
            data: JSON.stringify({
                Book: book,
                CommentText: $("#comment-txt-" + id).html(),
                User: $.session.get("User")
            }),
            contentType: 'application/json; charset=utf-8',

            success: function(result) {
                if (result.isSuccess == true) {
                    var c = parseInt($("#likeCount-" + id).html());
                    $("#likeCount-" + id).html(c + 1);
                    $("#likeBtn-" + id).html('<span id="linkLikeBtn-1" onclick="disLikeBtn(1)" class="link1 activeLink"><i class="fas fa-thumbs-up"></i> Beğendin</span>');

                } else {}
            },
            error: function(error) {}
        });
    }


}






function readBtn(id, book = "") {
    if (book != "") {
        $.ajax({
            url: 'http://localhost:62101/api/read/add-read',
            type: 'POST',

            dataType: 'json',
            data: JSON.stringify({
                Book: book,
                CommentText: $("#comment-txt-" + id).html(),
                User: $.session.get("User")
            }),
            contentType: 'application/json; charset=utf-8',

            success: function (result) {
                if (result.isSuccess == true) {
                    var c = parseInt($("#readCount-" + id).html());
                    $("#readCount-" + id).html(c + 1);
                    $("#readBtn-" + id).html('<span id="linkLikeBtn-1" onclick="disLikeBtn(1)" class="link1 activeLink"><i class="fas fa-thumbs-up"></i> Okudum</span>');

                } else { }
            },
            error: function (error) { }
        });
    }


}



function addComment(id, book = "",userr="") {
    if (book != "") {
        
        $.ajax({
            url: 'http://localhost:62101/api/comment/add-comment',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify({
                Book: book,
                CommentText: $("#comment-txt-" + id).html(),
                User: $.session.get("User")
            }),
            contentType: 'application/json; charset=utf-8',

            success: function (result) {
                if (result.isSuccess == true) {
                    $("#commentList-" + id).append('<div class="comment-item">' +
                        '<b>' + $.session.get("User") + '</b>' +
                        '<p>' + $("#comment-txt-" + id).html() + '</p>' +
                        '</div>');
                    $("#comment-txt-" + id).html("");
                } else { }
            },
            error: function (error) { }
        });
    }


}

function commentBtn(id) {
    $("#commentList-" + id).fadeToggle();

}

function message(type, title, body, id = "") {
    $("#message" + id).html('<div class="alert alert-' + type + ' alert-dismissible fade show" role="alert">' +
        '<strong>' + title + '</strong> ' + body +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span>' +
        '</button>' +
        '</div>');
}