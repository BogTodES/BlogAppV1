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


// get reacts
var reacts;
(function () {
    var reactUrl = $("#reactMeta").data("reacts-url");
    $.get({
        type: "GET",
        url: reactUrl
    })
        .done(function (data) {
            reacts = data;
            console.log(reacts);
        });
})();

// react to post

var sendPostReact = function (reactType, postId, postAddUrl) {
    $.ajax({
        url: postAddUrl,
        data: {
            postId: postId,
            reactId: reactType
        },
        success: function () {
            reactButPost.removeClass("btn-outline-dark");
            reactButPost.addClass("liked btn-info");
            console.log("added react to " + postId);
        },
        error: function () {
            console.log("nu o functionat da sa mor io daca stiu de ce");
        }
    });
}

var removePostReact = function (postId, postRemoveUrl) {
    // in caz ca exista deja react, la click se sterge
    $.ajax({
        url: postRemoveUrl,
        data: {
            postId: postId
        },
        success: function () {
            reactButPost.removeClass("liked btn-info");
            reactButPost.addClass("btn-outline-dark");
            console.log("removed react from " + postId);
        },
        error: function () {
            console.log("nu o functionat da sa mor io daca stiu de ce");
        }
    });
}

var sendCommReact = function (reactType, commId, commAddUrl) {
        $.ajax({
            url: commAddUrl,
            data: {
                commId: commId,
                reactId: reactType
            },
            success: function () {
                reactButPost.removeClass("btn-outline-dark");
                reactButPost.addClass("liked btn-info");
                console.log("added react to " + commId);
            },
            error: function () {
                console.log("nu o functionat da sa mor io daca stiu de ce");
            }
        });
}

var removeCommReact = function (commId, commRemoveUrl) {
    // in caz ca exista deja react, la click se sterge
    $.ajax({
        url: commRemoveUrl,
        data: {
            postId: commId
        },
        success: function () {
            reactButPost.removeClass("liked btn-info");
            reactButPost.addClass("btn-outline-dark");
            console.log("removed react from " + commId);
        },
        error: function () {
            console.log("nu o functionat da sa mor io daca stiu de ce");
        }
    });
}

var reactButPost = $("#reactButPost");
var postData = {
    postId: $("#wtf").data("post-id"),
    postUrlAdd: $("#wtf").data("post-url-add"),
    postUrlRemove: $("#wtf").data("post-url-remove")
};

reactButPost.on("click", function () {
    /*alert("postData = " + postData.postId);*/

    if (reactButPost.hasClass("liked")) {
        // in caz ca exista deja react, la click se sterge
        removePostReact(postData.postId, postData.postUrlRemove);
    }
    else {
        // nu reactionase inainte
        sendPostReact(1, postData.postId, postData.postUrlAdd);
    }
});

reactButPost.hover(
    function (event) {
        var triggerPostFloater = this;
        var cList = $('<ul/>')
            .addClass("clearfix")
            .addClass("position-absolute")
            .addClass("grow")
            .addClass("small")
            .addClass("list-group")
            .addClass("floater")
            .css("position", "absolute")
            .css("left", $(triggerPostFloater).position().left + "px")
            .css("top", $(triggerPostFloater).position().top + "px")
            .appendTo(document.activeElement)
            .fadeIn(500);

        $.each(reacts, function (i) {
            var li = $('<li/>')
                .addClass("list-group-item")
                .addClass("small")
                .addClass("h-2")
                .appendTo(cList);
            var r = $('<button/>')
                .addClass("small")
                .addClass("btn btn-secondary")
                .text(reacts[i].name)
                .attr("name", reacts[i].id)
                .click(function () {
                    sendPostReact(Number($(this).attr("name")), postData.postId, postData.postUrlAdd);
                    $(triggerPostFloater).text($(this).text());
                })
                .appendTo(li);
        });
    },
    function () {
        var cList = $('ul.floater');
        setTimeout(function () {
            /*cList = $('ul.reactFloater');*/
            cList.fadeOut();

        }, 2000);
        setTimeout(function () {
            $(cList).remove();
        }, 3000)
    }
);

// react to comm
var reactButCommList = $(".reactButComm");
var commUrls = {
    commUrlAdd: $("#commData").data("comm-url-add"),
    commUrlRemove: $("#commData").data("comm-url-remove")
}

var c = document.getElementsByClassName("reactButComm");
console.log(commUrls.commUrlAdd);

for (var reactButComm of c) {
    reactButComm = $(reactButComm);

    console.log(reactButComm);

    //commId = Number(reactButComm.attr("id"));

    // pt fiecare buton de comm adaug event-urile de click (like si unlike rapid)
    reactButComm.on("click", function () {
        let triggerCommReact = this;
        var commId = Number(thisBut.attr("id"));

        if ($(triggerCommReact).hasClass("liked")) {
            // in caz ca exista deja react, la click se sterge
            removeCommReact(commId, commUrls.commUrlRemove);
        }
        else {
            // nu reactionase inainte
            sendCommReact(1, commId, commUrls.commUrlAdd);
        }
    });

    reactButComm.hover(
        function (event) {
            var triggerCommFloater = this;
            var commId = Number($(triggerCommFloater).attr("id"));
            var cList = $('<ul/>')
                .addClass("clearfix")
                .addClass("position-absolute")
                .addClass("grow")
                .addClass("small")
                .addClass("list-group")
                .addClass("floater")
                .css("position", "absolute")
                .css("left", $(triggerCommFloater).position().left + "px")
                .css("top", $(triggerCommFloater).position().top + "px")
                .appendTo(document.activeElement)
                .fadeIn(500);
            
            $.each(reacts, function (i) {
                var li = $('<li/>')
                    .addClass("list-group-item")
                    .addClass("small")
                    .addClass("h-2")
                    .appendTo(cList);
                var r = $('<button/>')
                    .addClass("small")
                    .addClass("btn btn-secondary")
                    .text(reacts[i].name)
                    .attr("name", reacts[i].id)
                    .click(function () {
                        sendCommReact(Number($(this).attr("name")), commId, commUrls.commUrlAdd);
                        $(triggerCommFloater).text($(this).text());
                    })
                    .appendTo(li);
            });
        },
        function () {
            var cList = $('ul.floater');
            setTimeout(function () {
                /*cList = $('ul.reactFloater');*/
                cList.fadeOut();
            }, 2000);
            setTimeout(function () {
                $(cList).remove();
            }, 3000)
        }
    );
}




console.clear();
// -------------------------------------------------

var profileOfUrl = $("#goToUserPageMeta").data("user-page-url");


// search functionality
var searchUrl = $("#searchMeta").data("search-url");
var searchBar = $("#searchBar")

var renderSearchResults = function (data, searchbar) {
    var select = $('<select>').prop('id', 'results')
        .prop('name', 'results');

    $.each(data, function () {
        let newOpt = $("<option>");

        if (this.objectType === "UserResult") {
            newOpt.prop('value', this);

            var obj = JSON.parse(this.objectInfo);
            console.log(obj);

            var mainInfo = $('<h5/>')
                .text(obj.Username)
                .appendTo(newOpt);
            var secInfo = $('<h6/>')
                .text(obj.Blogs)
                .addClass("text-muted")
                .appendTo(newOpt);

            newOpt.click(function () {
                window.location.href = profileOfUrl + "/" + obj.UserId;
            });
        }

        select.append($(newOpt));
    });

    var label = $("<label>").prop('for', 'results')
        .text("We found: ");
    // var br = $("<br>");
    $('#searchResultContainer').append(label).append(select).append(br);

    /*var resultUl = $('<ul/>')
        .addClass('list-group-flush')
        .addClass('list-unstyled')
        .appendTo(searchbar);
    for (let i = 0; i < data.length; ++i) {
        var resultLi = $('<li/>')
            .add('list-item')
            .text(data[i])
            .appendTo(resultUl);
    }*/
}


var getSearchResults = function (thisBar) {
    var inputField = document.getElementById("searchBar");
    keyword = inputField.value;

    console.log(keyword);

    $.ajax({
        url: searchUrl,
        data: {
            keyword: keyword
        }
    }).done(function (data) {
        console.log(data);
        renderSearchResults(data, thisBar);
    });
}

var tid;
searchBar.keyup(function (e) {
    thisBar = this;
    clearTimeout(tid);
    tid = setTimeout(function () {
        getSearchResults(thisBar);
    }, 500);
})