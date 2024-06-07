const newsletter_submit = document.getElementById('newsletter_submit')
const toast = document.getElementById('toast')
const newsletter_input = document.getElementById('newsletter_input')
const toast_text = document.getElementById('toast_text')

const emailRegex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

const toast_bootstrap = bootstrap.Toast.getOrCreateInstance(toast)

const setWithExpiry = (key, value, ttl) => {
    const now = new Date();
    const item = {
        value: value,
        expiry: now.getTime() + ttl,
    };
    localStorage.setItem(key, JSON.stringify(item));
}

const getWithExpiry = (key) => {
    const itemStr = localStorage.getItem(key);
    if (!itemStr) {
        return null;
    }
    const item = JSON.parse(itemStr);
    const now = new Date();
    if (now.getTime() > item.expiry) {
        localStorage.removeItem(key);
        return null;
    }
    return item.value;
}

const setToastValue = (msg, type) => {
    toast_text.innerText = msg;
    toast.classList.add(type);
    setWithExpiry('toastMessage', msg, 2000);
    setWithExpiry('toastType', type);
}

if (getWithExpiry('showToast')) {
    // Show the toast here
    const msg = JSON.parse(localStorage.getItem("toastMessage")).value;
    const toastType = JSON.parse(localStorage.getItem("toastType")).value;
    toast_text.innerText = msg;
    toast.classList.add(toastType);
    toast_bootstrap.show();

    // Remove the flag from local storage after showing the toast
    localStorage.removeItem('showToast');
    localStorage.removeItem('toastMessage');
    localStorage.removeItem("toastType")
}


if (newsletter_submit) {
    newsletter_submit.addEventListener('click', () => {
        if (!newsletter_input.value.length) {
            setToastValue("Email address can't be empty!", "text-bg-danger")

        } else if (!emailRegex.test(newsletter_input.value)) {
            setToastValue("Please enter a valid email!", "text-bg-danger")
        }
        else {
            newsletter_input.value = null;
            toast.classList.remove('text-bg-danger');
            setToastValue("Thank you for subscribing to our newsletter!", "text-bg-success")
        }

        toast_bootstrap.show();
        setWithExpiry('showToast', true, 2000);
    })
}


const login_submit = document.getElementById('login_submit');

if (login_submit) {
    
}

const loginToast = () => {
    setToastValue("Successfully login!", "text-bg-success");
    toast_bootstrap.show();
    setWithExpiry('showToast', true, 2000);
}