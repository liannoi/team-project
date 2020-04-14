'use strict';

function runtime() {
    const softDeleter = new SoftDeleter(document.querySelectorAll('.btn-delete'),
        '/ActorsWebUi/Delete',
        'Actor successfully removed.');
    softDeleter.subscribeToDelete();
}

runtime();