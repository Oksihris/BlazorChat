

const storage = window.localStorage;

window.getFromStorage = (key) => storage.getItem(key);

window.setToStorage = (key, value) => storage.setItem(key, value);
