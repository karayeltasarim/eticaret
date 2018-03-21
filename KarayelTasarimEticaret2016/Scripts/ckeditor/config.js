/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.toolbar = 'MyToolbar';
    config.enterMode = CKEDITOR.ENTER_BR;
    config.shiftEnterMode = CKEDITOR.ENTER_P;
    config.toolbar = 'Full';
   /* config.toolbar_MyToolbar =
    [
        ['Source'], ['Bold', 'Italic', 'Underline', 'Strike'], ['NumberedList', 'BulletedList'], ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'], ['Link', 'Unlink'], ['Maximize'],
        '/',
        ['Format', 'TextColor', 'BGColor', 'PasteFromWord', '-', 'RemoveFormat', 'SpecialChar', 'Outdent', 'Indent'],
        ['Image', 'Flash', 'Table'],
        ['Undo', 'Redo']
    ]; */
};
