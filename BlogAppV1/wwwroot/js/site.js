﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.




// Write your JavaScript code.
$(document).ready(function () {

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
        setTimeout(function () {
            document.location.href = redirectToBlogUrl;
        }, 200);
    });


    // remove section

    var removeSectUrl = $("#removeSectMeta").data("del-sect-url");
    var removeSectButs = $(".removeSection");

    $.each(removeSectButs, function (i) {
        $(removeSectButs.get(i)).click(function () {
            var thisRemoveSectBut = this;
            var sectToDeleteId = Number($(thisRemoveSectBut).attr("id").slice(2));

            $.ajax({
                type: "delete",
                url: removeSectUrl,
                data: {
                    sectId: sectToDeleteId
                },
                success: function () {
                    console.log("da frate am sters sectId " + sectToDeleteId);
                    document.location.reload();
                },
            });
        });
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
            newBody: newBody.textContent,
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
            error: function () {
            }
        });

    });

    // remove post

    var delPostUrl = $("#removePostMeta").data("del-post-url");
    var delPostButs = $(".removePost");
    $.each(delPostButs, function (i) {
        $(delPostButs.get(i)).click(function () {
            var thisDelPostBut = this;
            var postToDeleteId = Number($(thisDelPostBut).attr("id").slice(2));

            console.log("incerc sa sterg postId" + postToDeleteId + " folosind " + delPostUrl);

            $.ajax({
                type: "delete",
                url: delPostUrl,
                data: {
                    postId: postToDeleteId
                },
                success: function () {
                    console.log("felicitari am sters post " + postToDeleteId)
                    document.location.reload();
                },
                error: function () {
                    console.log("what dafak");
                }
            })
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



    // delete comment
    var delCommUrl = $("#removeCommMeta").data("del-comm-url");
    var commDelButs = $(".removeComm");

    $.each(commDelButs, function (i) {
        $(commDelButs.get(i)).click(function () {
            var thisCommDelBut = this;
            var commToDeleteId = Number($(thisCommDelBut).attr("id").slice(2));
            $.ajax({
                url: delCommUrl,
                data: {
                    commId: commToDeleteId
                },
                success: function () {
                    console.log("sters comm " + commToDeleteId);
                    document.location.reload();
                },
                error: function (errorAns) {
                    console.log(errorAns.responseText);
                }
            });
        });
    });


    //-----------------------------------------------------------------

    // react functionality


    var commUrls = {
        commUrlAdd: $("#commData").data("comm-url-add"),
        commUrlRemove: $("#commData").data("comm-url-remove")
    }

    var postUrls = {
        postUrlAdd: $("#wtf").data("post-url-add"),
        postUrlRemove: $("#wtf").data("post-url-remove")
    };

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

    var sendCommReact = function (reactType, commId, commAddUrl) {
        $.ajax({
            url: commAddUrl,
            data: {
                commId: commId,
                reactId: reactType
            },
            success: function () {
                console.log("added react to " + commId);
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



    var removeCommReact = function (commId, commRemoveUrl) {
        // in caz ca exista deja react, la click se sterge
        $.ajax({
            url: commRemoveUrl,
            data: {
                commId: commId
            },
            success: function () {
                console.log("removed react from " + commId);
            },
            error: function () {
                console.log("nu o functionat da sa mor io daca stiu de ce");
            }
        });
    }

    // get reacts
    var reacts;
    (function () {
        var fillCommReactsLinks = function (container) {
            var commId = Number($(container).parent("div.dropright").attr("id").slice(4));
            
            $.each(reacts, function (i) {
                var react = reacts[i];
                var newa = $('<a/>')
                    .text(react.name)
                    .addClass("dropdown-item btn btn-outline-secondary border-dark rounded-pill")
                    .attr("name", react.id)
                    .click(function () {
                        var currentA = this;
                        sendCommReact(Number($(currentA).attr("name")), commId, commUrls.commUrlAdd);
                        $("#mainCommReact_" + commId)
                            .text($(currentA).text())
                            .addClass("btn-info liked");
                    })
                    .appendTo($(container));
            });
        }

        var fillCommReacts = function (reacts) {
            var commReactDropdowns = $(".commReactDropdown");
            $.each(commReactDropdowns, function (index) {
                var currentDropdown = commReactDropdowns.get(index);
                console.log(currentDropdown);
                fillCommReactsLinks(currentDropdown);
            });

            var mainCommReacts = $(".reactButComm");
            $.each(mainCommReacts, function (i) {
                var currentBut = mainCommReacts.get(i);

                $(currentBut).click(function () {
                    var thisBut = this;
                    var commId = Number($(thisBut).attr("id").slice(14));

                    if ($(thisBut).hasClass("liked")) {
                        // daca era liked si apas din nou, se sterge reactu
                        removeCommReact(commId, commUrls.commUrlRemove);
                        $(thisBut).removeClass("liked btn-info");
                        $(thisBut).addClass("btn-secondary");
                    }
                    else {
                        // altfel dau like simplu
                        sendCommReact(1, commId, commUrls.commUrlAdd);
                        $(thisBut).removeClass("btn-secondary");
                        $(thisBut).addClass("liked btn-info");
                    }
                });
            });
        }



        var fillPostReactsLinks = function (container) {
            var postId = Number($(container).parent("div.dropdown").attr("id").slice(4));

            $.each(reacts, function (i) {
                var react = reacts[i];
                var newa = $('<a/>')
                    .text(react.name)
                    .addClass("dropdown-item btn btn-outline-secondary border-dark rounded-pill")
                    .attr("name", react.id)
                    .click(function () {
                        var currentA = this;
                        sendPostReact(Number($(currentA).attr("name")), postId, postUrls.postUrlAdd);
                        $("#mainPostReact_" + postId)
                            .text($(currentA).text())
                            .addClass("btn-info liked");
                    })
                    .appendTo($(container));
            })
        } 


        var fillPostReacts = function (reacts) {
            var postReactDropdowns = $(".postReactDropdown");
            $.each(postReactDropdowns, function (i) {
                var currentDropdown = postReactDropdowns.get(i);
                console.log(currentDropdown);
                fillPostReactsLinks(currentDropdown);
            })

            var mainPostReacts = $(".reactButPost");
            $.each(mainPostReacts, function (i) {
                var currentBut = mainPostReacts.get(i);

                $(currentBut).click(function () {
                    var thisBut = this;
                    var postId = Number($(thisBut).attr("id").slice(14));

                    if ($(thisBut).hasClass("liked")) {
                        // daca era liked si apas din nou, se sterge reactu
                        removePostReact(postId, postUrls.postRemoveUrl);
                        $(thisBut).removeClass("liked btn-info");
                        $(thisBut).addClass("btn-secondary");
                    }
                    else {
                        // altfel dau like simplu
                        sendPostReact(1, postId, postUrls.postUrlAdd);
                        $(thisBut).removeClass("btn-secondary");
                        $(thisBut).addClass("liked btn-info");
                    }
                });
            });
        }


        var reactUrl = $("#reactMeta").data("reacts-url");
        $.get({
            type: "GET",
            url: reactUrl
        })
            .done(function (data) {
                reacts = data;
                console.log(reacts);
                fillCommReacts(reacts);
                fillPostReacts(reacts);
            });


    })();
    // react to post

    var reactButPost = $("#reactButPost");
    


    // -------------------------------------------------

    var profileOfUrl = $("#goToUserPageMeta").data("user-page-url");
    var blogPageUrl = $("#goToBlogPageMeta").data("blog-page-url");
    var sectPageUrl = $("#goToSectionMeta").data("sect-page-url");

    // search functionality
    var searchUrl = $("#searchMeta").data("search-url");
    var searchBar = $("#searchBar");
    var searchResultsDropdown = $("#searchResultContainer");

    var renderSearchResults = function (data, searchbar) {
        /*var dropMenu = $('<div/>')
            .addClass("dropdown-menu")
            .attr("id", "dropMenu")
            .appendTo($("#searchResultContainer"));*/

        $.each(data, function () {
            /*let infoDiv = $('<div/>')
                .addClass("dropdown-item")
                .appendTo(searchResultsDropdown);*/

            switch (this.objectType) {
                case "UserResult":
                    var obj = JSON.parse(this.objectInfo);
                    console.log(obj);

                    var item = $('<a/>')
                        .addClass("text-dark dropdown-item")
                        .attr("href", profileOfUrl + "?username=" + obj.Username)
                        .appendTo(searchResultsDropdown);

                    var div = $('<div/>')
                        .addClass("resultDiv")
                        .appendTo(item);

                    var mainInfo = $('<h5/>')
                        .text(obj.Username)
                        .addClass("font-weight-bold text-primary")
                        .appendTo(div);
                    // $('<br>').appendTo(div);
                    if (obj.Blogs != "") {
                        var secInfo = $('<h6/>')
                            .addClass("text-secondary")
                            .appendTo(div);

                        $('<span/>')
                            .text(" owns " + obj.Blogs)
                            .addClass("text-dark")
                            .appendTo(secInfo);
                    }
                    else {
                        var secInfo = $('<h6/>')
                            .text("no blogs")
                            .addClass("text-secondary")
                            .appendTo(div);
                    }

                    break;

                case "BlogResult":
                    var obj = JSON.parse(this.objectInfo);
                    console.log(obj);

                    var item = $('<a/>')
                        .addClass("text-dark dropdown-item")
                        .attr("href", blogPageUrl + "/" + obj.BlogId)
                        .appendTo(searchResultsDropdown);

                    var div = $('<div/>')
                        .addClass("resultDiv")
                        .appendTo(item);

                    var mainInfo = $('<h5/>')
                        .text(obj.Title)
                        .addClass("font-weight-bold text-info")
                        .appendTo(div);

                    var secInfo = $('<h6/>')
                        .addClass("text-secondary")
                        .text(" owned by ")
                        .appendTo(div);

                    $('<span/>')
                        .text(obj.OwnerName)
                        .addClass("text-dark")
                        .appendTo(secInfo);

                    break;

                case "SectionResult":
                    var obj = JSON.parse(this.objectInfo);
                    console.log(obj);
                    console.log(sectPageUrl + "?sectId=" + obj.SectId)
                    var item = $('<a/>')
                        .addClass("text-dark dropdown-item")
                        .attr("href", sectPageUrl + "?sectId=" + obj.SectId)
                        .appendTo(searchResultsDropdown);

                    var div = $('<div/>')
                        .addClass("resultDiv")
                        .appendTo(item);

                    var mainInfo = $('<h5/>')
                        .text(obj.Name)
                        .addClass("font-weight-bold text-success")
                        .appendTo(div);

                    if (obj.Blogs != "") {
                        var secInfo = $('<h6/>')
                            .addClass("text-secondary")
                            .appendTo(div);
                        $('<span/>')
                            .text("is found in " + obj.Blogs)
                            .addClass("text-dark")
                    }
                    break;
                default:
                    break;
            }
            $('<div/>').addClass("dropdown-divider").appendTo(searchResultsDropdown);

        });

        $("#dropDownToggle").trigger("click");
    }


    var getSearchResults = function (thisBar) {
        var inputField = document.getElementById("searchBar");
        keyword = inputField.value;

        deleteOldresults(thisBar);

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

    var deleteOldresults = function (searchBar) {
        /*$("#results").remove();
        $("#resultLabel").remove();
        $("#resultBr").remove();*/
        $(searchResultsDropdown).removeClass("dropdown-toggle");
        $("#dropMenu").children().remove();
        $("#dropMenu").remove();
        $(".dropdown-divider").remove();
        $(".dropdown-item").remove();
    }

    var tid;
    /*searchBar.keypress(function (e) {
        thisBar = this;
        clearTimeout(tid);
        if (e.keyCode == 8) {
            deleteOldresults(thisBar);
        }
        tid = setTimeout(function () {
            $(searchResultsDropdown).addClass("dropdown-toggle");
            deleteOldresults(thisBar);
            getSearchResults(thisBar);
        }, 200);
    });*/

    searchBar.keypress(function (e) {
        thisBar = this;
        if (e.keyCode == 13) {
            clearTimeout(tid);
            tid = setTimeout(function () {
                $(searchResultsDropdown).addClass("dropdown-toggle");
                getSearchResults(thisBar);
            }, 500);
        }
    })


    //----------------------------------------------

    // friendship functionality
    var sendRequestUrl = $("#sendFriendRequestMeta").data("send-fr-req-url");
    var acceptFriendRequestUrl = $("#acceptFriendRequestMeta").data("accept-fr-req-url");
    var hideFriendRequestUrl = $("#hideFriendRequestsMeta").data("hide-fr-req-url");

    // friends list stuff
    $('.dropdown-menu').click(function (e) {
        e.stopPropagation();
    });

    var friendsListDiv = $("#friendListDisplay");
    var friendLists;

    (function () {
        // iau listele de prieteni
    }());



    var confirmReqButs = $(".confirmReq");
    $.each(confirmReqButs, function (i) {
        var iCRB = confirmReqButs.get(i);
        $(iCRB).click(function () {
            var thisBut = this;
            var senderId = Number($(thisBut).attr("id").slice(8));

            $.ajax({
                url: acceptFriendRequestUrl,
                data: {
                    senderId: senderId
                },
                success: function () {
                    console.log("felicitari esti prieten cu " + senderId);
                    $("#friendsDropdown").dropdown('update');
                    $(".req_" + senderId).remove();
                    document.location.reload();
                }
            });
        });
    });


    var declineReqButs = $(".declineReq");
    $.each(declineReqButs, function (i) {
        var iDRB = declineReqButs.get(i);
        $(iDRB).click(function () {
            var thisBut = this;
            var senderId = Number($(thisBut).attr("id").slice(5));

            $.ajax({
                url: hideFriendRequestUrl,
                data: {
                    senderId: senderId
                },
                success: function () {
                    console.log("felicitari ai dat decline la " + senderId);
                    $("#friendsDropdown").dropdown('update');
                    $(".req_" + senderId).remove();
                    document.location.reload();
                }
            });
        });
    });



    // unfriend
    var unfriendBut = $("#unfriendBut");
    var unfriendUrl = $(unfriendBut).data("unfriend-url");

    unfriendBut.click(function () {
        var senderId = Number($(this).attr("name"));

        $.ajax({
            url: unfriendUrl,
            data: {
                unfriendId: senderId
            },
            success: function () {
                console.log("bv nu mai esti prieten cu " + senderId);
                document.location.reload();
            }
        });
    });


    // add friend
    var addFriendButs = $(".sendFrReqBut");

    $.each(addFriendButs, function (i) {
        var b = addFriendButs.get(i);
        $(b).click(function () {
            var thisAddFrBut = this;
            var receiverId = Number($(thisAddFrBut).attr("name"));

            $.ajax({
                url: sendRequestUrl,
                data: {
                    toUserId: receiverId
                },
                success: function () {
                    console.log("ok vere vezi poate-ti raspunde " + receiverId);
                    document.location.reload();
                }
            });
        });
    });


    // remove (retract) request, eu am trimis-o

    var removeRequestBut = $("#removeFrReqBut");
    removeRequestBut.click(function () {
        var receiverId = Number($(this).attr("name"));
        var removeFrReqUrl = $(this).data("remove-req-url");

        $.ajax({
            url: removeFrReqUrl,
            data: {
                receiverId: receiverId
            },
            success: function () {
                console.log("ok nu mai vrei safii prieten cu " + receiverId);
                document.location.reload();
            }
        });
    });


    // --------------------------------------------------------

    // unblocking functionality

    var unblockPersButs = $(".personalBlockBut");
    var unblockPersUrl = $("#unblockPersonalUrl").data("ublock-pers-url");

    $.each(unblockPersButs, function (i) {
        var UPB = unblockPersButs.get(i);
        $(UPB).click(function () {
            var thisUPB = this;
            var unblockId = Number($(thisUPB).attr("id").slice(8));

            $.ajax({
                url: unblockPersUrl,
                data: {
                    blockedId: unblockId
                },
                success: function () {
                    console.log("ok l-ai deblocat pe " + unblockId);
                    $(thisUPB).parentsUntil("div.dropdown-item").remove();
                    $(thisUPB).remove();
                    document.location.reload();
                }
            });
        });
    });



    //------------------------


    // media stuff

    console.log($("#actualProfilePic").attr("src"));


    // ---------------------------- main page grid system 

    function resizeGridItem(item) {
        grid = document.getElementsByClassName("grid")[0];
        rowHeight = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-auto-rows'));
        rowGap = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-row-gap'));
        rowSpan = Math.ceil((item.querySelector('.content').getBoundingClientRect().height + rowGap) / (rowHeight + rowGap));
        item.style.gridRowEnd = "span " + rowSpan;
    }

    function resizeAllGridItems() {
        allItems = document.getElementsByClassName("item");
        for (x = 0; x < allItems.length; x++) {
            resizeGridItem(allItems[x]);
        }
    }

    function resizeInstance(instance) {
        item = instance.elements[0];
        resizeGridItem(item);
    }

    window.onload = resizeAllGridItems();
    window.addEventListener("resize", resizeAllGridItems);

/*allItems = document.getElementsByClassName("item");
for (x = 0; x < allItems.length; x++) {
    imagesLoaded(allItems[x], resizeInstance);
}*/


    //--------------------- nu atingeti
});