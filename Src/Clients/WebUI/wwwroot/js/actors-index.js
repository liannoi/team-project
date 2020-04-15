'use strict';

function runtime() {
    const softDeleter = new SoftDeleter(document.querySelectorAll('.btn-cmd-delete'),
        '/ActorsWebUi/DeleteActor',
        'Actor successfully removed.');
    softDeleter.subscribeToDelete();
}

runtime();