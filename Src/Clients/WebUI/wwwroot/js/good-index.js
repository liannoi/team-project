'use strict';

function DeleteItem() {
    const softDeleter = new SoftDeleter(document.querySelectorAll('.btn-delete'),
        '/ActorsWebUI/Delete',
        'Good successfully removed.');
    softDeleter.subscribeToDelete();
}

DeleteItem();