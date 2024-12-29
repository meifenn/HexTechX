function navigateTo(url) {
    window.location.href = url;
}

window.bootstrapModal = {
    show: (selector) => {
        const modal = new bootstrap.Modal(document.querySelector(selector));
        modal.show();
    }
};


