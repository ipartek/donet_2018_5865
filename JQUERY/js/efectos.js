/*global $*/
/*jslint devel: true, plusplus: true, continue: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

$(function () {
    'use strict';
    
    $('article p').hide();
    
    $('article h2').click(function () {
        $(this).nextAll('p').fadeToggle();
    });
    
    $('h2').each(function () {
        console.log($(this).html());
        console.log(this.innerHTML);
    });
});