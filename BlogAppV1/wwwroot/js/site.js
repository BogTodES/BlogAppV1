// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




// creation of new sections
var sectionsDiv = $("#sectionsContainer");
var addSectBut = $("#newSectBut");
var addSectUrl = $("#saveChangesAction").data("register-section-url");

// generez un div nou temporar in care user-ul poate sa introduca titlul sectiunii, 
// marchez titlurile inserate ca fiind introduse noi ca sa pot sa le accesez mai incolo
// in final, doar titlurile sunt importante
addSectBut.on("click", function () {
    var newSectBox = document.createElement('div');
    $(newSectBox).addClass("col border-info rounded m-3")
        .attr('id', 'newSect')
        .appendTo(sectionsDiv);

    var newSectData = document.createElement('div');
    $(newSectData).addClass("border border-danger")
        .text("Section title: ")
        .appendTo(newSectBox);

    var sectName = document.createElement('h3');
    $(sectName).addClass("text-capitalize newSectTitle")
        .attr('contenteditable', 'true')
        /*.attr('id', 'newSectTitle')*/
        .text("New Section")
        .appendTo(newSectData);
});

// inregistrez 1 sectiune noua prin AJAX
var addSection = function (name, blogId) {
    var data = {
        name: name,
        blogId: blogId
    };

    $.ajax({
        type: "POST",
        url: addSectUrl,
        data: data,
        success: function () {
            console.log("inserted section { " + data.name + ", " + data.blogId + " }");
        }
    });
}

var updateSectNames = function (updatedTitle, sectionId) {
    // updateaza-le si pe alea vechi

}

// pt fiecare sectiune nou introdusa, o trimit in baza de date
var saveSectionsChanges = function (oldSectNames, newSectNames, blogId) {
    for (var i = 0; i < newSectNames.length; i += 1) {
        var name = newSectNames.get(i).textContent;

        // introduc o sectiune noua doar daca are nume, si este diferit de cel default
        if (name.length > 0 && name.localeCompare("New Section") != 0)
            addSection(name, blogId);
    }
}

var updateBlogTitleUrl = $("#saveBlogTitleAction").data("update-blog-title-url");
// daca modific titlul, inregistrez si asta prin AJAX
var updateBlogTitle = function (newTitle, blogId) {
    var data = {
        newTitle: newTitle,
        blogId: blogId
    };

    $.ajax({
        type: "POST",
        url: updateBlogTitleUrl,
        data: data,
        success: function () {
            console.log("updated title to " + data.newTitle);
        }
    });
}

// la click pe buton, sunt salvate toate modificarile inregistrate
var saveChangesBut = $("#saveChangesBut");
var redirectToBlogUrl = $("#saveChangesAction").data("redirect-to-blog");

saveChangesBut.on("click", function () {
    var blogId = Number(saveChangesBut.attr("name"));

    var newSectNames = $(".newSectTitle");

    var oldSectNames = $("h3").not(".newSectTitle") // updatez si titlurile vechi
    saveSectionsChanges(oldSectNames, newSectNames, blogId);

    var newBlogTitle = $("#title");
    updateBlogTitle(newBlogTitle.get(0).textContent, blogId);

    // alert("am icnercat sa il trimit la " + redirectToBlogUrl)
    document.location.href = redirectToBlogUrl;
});



//----------------------------------------------------------------



// add new post
var addPostBut = $("#addNewPostBut");
var addPostUrl = $("#addNewPostAction").data("add-new-post-url");
addPostBut.on("click", function () {

    var newTitle = $("#newTitle").get(0);
    var newBody = $("#newBody").get(0);
    var sectId = Number(addPostBut.attr("name"));

    if (newTitle.textContent.length == 0)
        return;

    var ceTrimit = {
        newTitle: newTitle.textContent,
        newBody: newBody.value,
        sectionId: sectId
    };

    $.ajax({
        type: "POST",
        url: addPostUrl,
        data: ceTrimit,
        success: function (response) {
            if (response.flag && response.flag == true) {
                console.log("introdus post nou pentru sect " + sectId);
                document.location.reload();
            }
            else {
                alert("Error at adding post!");
            }
        },
        error: function(){
        }
    });

});


//----------------------------------------------------------------



// add a comment
var addCommBut = $("#addCommentBut");
var addCommData = $("#addCommentAction");

var sendComment = function () {
    /*var commenterId = Number(addCommData.data("commenterId"));*/
    var postId = Number(addCommBut.attr("name"));

    var commBody = $("#newCommentBody").get(0).value;

    if (commBody.length <= 0)
        return;

    var deTrimis = {
        body: commBody,
        postId: postId,
        /*commenterId: commenterId*/
    };

    // alert("de trimis = { body = " + commBody + ", " + postId + " } la adresa " + addCommData.data("add-comment-url"));

    $.ajax({
        type: "POST",
        url: addCommData.data("add-comment-url"),
        data: deTrimis,
        success: function () {
            console.log("added comment");
            document.location.reload();
        }
    });
}

addCommBut.on("click", sendComment); // trimit comm daca dau click pe buton
$("#newCommentBody").keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    console.log(keycode);
    if (keycode == '13') {
        
        
        sendComment();
    }
}); // daca am apasat enter pe textbox, trimit comentariul



//-----------------------------------------------------------------



// react button

var reactBut = $()