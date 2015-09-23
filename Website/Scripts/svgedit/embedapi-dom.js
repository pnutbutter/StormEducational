/*globals $, EmbeddedSVGEdit*/
/*jslint vars: true */
var initEmbed;

// Todo: Get rid of frame.contentWindow dependencies so can be more easily adjusted to work cross-domain

$(function () {
    'use strict';

    var svgCanvas = null;
    var frame;

    initEmbed = function () {
        
        var doc, mainButton;
        frame = document.getElementById('svgedit');
        svgCanvas = new EmbeddedSVGEdit(frame);
            
        if (frame.contentDocument) // FF Chrome
            doc = frame.contentDocument;
        else if (frame.contentWindow) // IE
            doc = frame.contentWindow.document;
        mainButton = doc.getElementById('main_button');
        mainButton.style.display = 'none';
        svgCanvas.setSvgString($('#show-sketch').html());
        
        
    };

    function handleSvgData(data, error) {
        if (error) {
            alert('error ' + error);
        } else {
            $('#show-sketch').html('');
            $('#show-sketch').html(data);
            $("#sketch-wrapper").show();
            $("#sketch-edit-wrapper").hide();
            //$('#svgeditwrapper').html('');
            //alert(data);
        }
        //alert(data);
    }

    function saveSvg() {
        svgCanvas.getSvgString()(handleSvgData);
    }


    // Add event handlers
    $("#edit-sketch").click(function (e) {
        e.preventDefault();
        $("#sketch-wrapper").hide();
        $("#sketch-edit-wrapper").show();
        //alert($('#svgedit').length);
        if ($('#svgedit').length<1)
        {
        $('#svgeditwrapper').append(
            $('<iframe src="/Scripts/svgedit/svg-editor.html?extensions=ext-xdomain-messaging.js' +
                    window.location.href.replace(/\?(.*)$/, '&$1') + // Append arguments to this file onto the iframe
                    '" width="900px" height="600px" id="svgedit" onload="initEmbed();"></iframe>'
                )
        );
        }
        if(svgCanvas)
            svgCanvas.setSvgString($('#show-sketch').html());
        
    });
    $('#save-sketch').click(function (e) {
        e.preventDefault();
        svgCanvas.getSvgString()(handleSvgData);
        
    });

    
    
});
