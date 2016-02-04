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
            $('#Sketch').val(data);
            //$("#sketch-wrapper").show();
            //$("#sketch-edit-wrapper").hide();
            //$('#svgeditwrapper').html('');
            //alert(data);
        }
        //alert(data);
    }

    function saveSvg() {
        svgCanvas.getSvgString()(handleSvgData);
    }

    $('#save-sketch').click(function (e) {
        e.preventDefault();
        svgCanvas.getSvgString()(handleSvgData);
        $('#myModal').modal('hide');
    });

    
    
});
