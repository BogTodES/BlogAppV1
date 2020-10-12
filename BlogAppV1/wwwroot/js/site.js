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

var reactButPost = $("#reactButPost");
var postData = {
    postId: $("#wtf").data("post-id"),
    postUrlAdd: $("#wtf").data("post-url-add"),
    postUrlRemove: $("#wtf").data("post-url-remove")
};

reactButPost.on("click", function () {
    /*alert("postData = " + postData.postId);*/

    if (reactButPost.hasClass("liked")) {
        console.log(postData.postId + " " + postData.postUrlAdd + " " + postData.postUrlRemove);
        // in caz ca exista deja react, la click se sterge
        $.ajax({
            url: postData.postUrlRemove,
            data: {
                postId: postData.postId
            },
            success: function () {
                reactButPost.removeClass("liked btn-info");
                reactButPost.addClass("btn-outline-dark");
                console.log("removed react from " + postData.postId);
            },
            error: function () {
                console.log("nu o functionat da sa mor io daca stiu de ce");
            }
        });
    }
    else {
        // nu reactionase inainte
        console.log(postData.postId + " " + postData.postUrlAdd + " " + postData.postUrlRemove);
        $.ajax({
            url: postData.postUrlAdd,
            data: {
                postId: postData.postId,
                reactId: 1
            },
            success: function () {
                reactButPost.removeClass("btn-outline-dark");
                reactButPost.addClass("liked btn-info");
                console.log("added react to " + postData.postId);
            },
            error: function () {
                console.log("nu o functionat da sa mor io daca stiu de ce");
            }
        });
    }
});

reactButPost.hover(
    function (event) {
        console.log("nush ce are vere");
        var thisBut = this;
        var cList = $('<ul/>')
            .addClass("clearfix")
            .addClass("position-absolute")
            .addClass("grow")
            .addClass("small")
            .addClass("list-group")
            .addClass("floater")
            .css("position", "absolute")
            .css("left", $(thisBut).position().left + "px")
            .css("top", $(thisBut).position().top + "px")
            .appendTo(document.activeElement)
            .fadeIn(500);
        //console.log("cica like-u se afla la " + $(thisBut).position().left + " si " + $(thisBut).position().top);

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

    commId = Number(reactButComm.attr("id"));

    // pt fiecare buton de comm adaug event-urile de click (like si unlike rapid)
    reactButComm.on("click", function () {
        thisBut = $(this);
        commId = Number(thisBut.attr("id"));

        if (thisBut.hasClass("liked")) {
            // in caz ca exista deja react, la click se sterge
            $.ajax({
                url: commUrls.commUrlRemove,
                data: {
                    commId: commId
                },
                success: function () {
                    thisBut.removeClass("liked btn-info");
                    thisBut.addClass("btn-outline-dark");
                    console.log("removed react from " + commId);
                },
                error: function () {
                    console.log("nu o functionat da sa mor io daca stiu de ce");
                }
            });
        }
        else {
            // nu reactionase inainte
            $.ajax({
                url: commUrls.commUrlAdd,
                data: {
                    commId: commId,
                    reactId: 1
                },
                success: function () {
                    thisBut.removeClass("btn-outline-dark");
                    thisBut.addClass("liked btn-info");
                    console.log("added react to " + commId);
                },
                error: function () {
                    console.log("nu o functionat da sa mor io daca stiu de ce");
                }
            });
        }
    });

    reactButComm.hover(
        function (e) {
            var floater = $('<div class="reactFloater">aici</div>').css({
                "left": e.pageX + 'px',
                "bottom": e.pageY + 'px'
            });
            $(this).parent().append(
                floater
            );
            console.log($(floater));
            setTimeout(function () {
                $(floater).addClass("grow");
            }, 200);
        },
        function () {
            $("div.reactFloater").remove();
        }
    );

    /*reactButComm.on("mouseenter", function (e) {
        var reactFloater = $('<div class="reactFloater">aici</div>')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .appendTo(document.body);
        console.log(reactFloater);
        setTimeout(function () {
            reactFloater.addClass("grow");
        }, 200);
    });
    reactButComm.on("mouseleave", function () {
        var reactFloater = $(".reactFloater");
        setTimeout(function () {
            reactFloater.removeClass("grow");
            reactFloater.addClass("fade-out");
        }, 100);
    });*/
}

