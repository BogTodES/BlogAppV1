// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// creation of new section
var sectionsDiv = $("#sectionsContainer");
var addSectBut = $("#newSectBut");
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


var addSection = function (name, blogId) {
    var data = {
        name: name,
        blogId: blogId
    };

    $.ajax({
        type: "POST",
        url: "../../Section/AddSection",
        data: data,
        success: function () {
            console.log("inserted section { " + data.name + ", " + data.blogId + " }");
        }
    });
}

var updateSections = function (newSectNames, blogId) {
    for (var i = 0; i < newSectNames.length; i += 1) {
        var h3 = newSectNames.get(i);
        addSection(h3.textContent, blogId);
    }
}

var updateBlogTitle = function (newTitle, blogId) {
    var data = {
        newTitle: newTitle,
        blogId: blogId
    };

    $.ajax({
        type: "POST",
        url: "../../Blog/UpdateTitle",
        data: data,
        success: function () {
            console.log("updated title to " + data.newTitle);
        }
    });
}

var saveChangesBut = $("#saveChangesBut");
saveChangesBut.on("click", function () {
    var blogId = Number(saveChangesBut.attr("name"));

    var newSectNames = $(".newSectTitle");
    updateSections(newSectNames, blogId);

    var newBlogTitle = $("#title");
    updateBlogTitle(newBlogTitle.get(0).textContent, blogId);
});