function navigateTo(url) {
    window.location.href = url;
}

window.bootstrapModal = {
    show: (selector) => {
        const modal = new bootstrap.Modal(document.querySelector(selector));
        modal.show();
    }
};

window.readFileAsDataURL = async (file) => {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = (event) => resolve(event.target.result);
        reader.onerror = (error) => reject(error);
        reader.readAsDataURL(file);
    });
};



