import { baseUrl } from '/js/config.js'; 
export function checkUserAuthentication(requiredRole = null) {
    return new Promise((resolve, reject) => {
        const token = localStorage.getItem('authToken');
        if (!token) {
            showToast('No authentication token found.', 'error');
            window.location.href = '/Auth/Login';
            reject('No auth token found');
            return;
        }
        var url = baseUrl + '/api/identity/currentUser';
        fetch(url, {
            method: 'GET',
            headers: { 'Authorization': `Bearer ${token}` },
        })
            .then(response => {
                if (!response.ok) {
                    showToast('Authentication failed.', 'error');
                    window.location.href = '/Auth/Login';
                    reject('Failed to authenticate');
                    return;
                }
                return response.json();
            })
            .then(data => {
                if (requiredRole && (!data.roles || !data.roles.includes(requiredRole))) {
                    showToast('Access denied.', 'error');
                    window.location.href = '/Auth/AccessDenied';
                    reject(`Access denied for role: ${requiredRole}`);
                    return;
                }
                resolve(data);
            })
            .catch(error => {
                console.error('Error fetching user information:', error);
                showToast('Authentication error.', 'error');
                window.location.href = '/Auth/Login';
                reject(error);
            });
    });
}

export function showToast(message, type = 'success') {
    const toastColor = type === 'success' ? 'green' : 'red';
    const toastDiv = document.createElement('div');
    toastDiv.textContent = message;
    toastDiv.style.position = 'fixed';
    toastDiv.style.top = '20px';
    toastDiv.style.right = '20px';
    toastDiv.style.backgroundColor = toastColor;
    toastDiv.style.color = 'white';
    toastDiv.style.padding = '10px';
    toastDiv.style.borderRadius = '5px';
    document.body.appendChild(toastDiv);

    setTimeout(() => {
        toastDiv.remove();
    }, 3000);
}
