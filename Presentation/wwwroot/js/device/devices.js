// devices.js
import { BaseUrl } from '/js/config.js';  // Nhập baseUrl từ tệp config.js

let currentPage = 1;
const itemsPerPage = 10;
const Author = 'Bearer YOUR_TOKEN_HERE';
async function fetchOptions() {
    try {
        const deviceTypeResponse = await fetch(BaseUrl + '/api/device_type', {
            method: 'GET',
            headers: {
                'Authorization': Author, 
                'Content-Type': 'application/json'
            }
        });
        const deviceTypes = await deviceTypeResponse.json();
        populateSelect('deviceType', deviceTypes, 'name');

        const locationResponse = await fetch(BaseUrl+'/api/locations', {
            method: 'GET',
            headers: {
                'Authorization': Author, 
                'Content-Type': 'application/json'
            }
        });
        const locations = await locationResponse.json();
        populateSelect('location', locations, 'description');
    } catch (error) {
        console.error('Error fetching options:', error);
    }
}

function populateSelect(elementId, options, displayProperty) {
    const select = document.getElementById(elementId);
    options.forEach(option => {
        const opt = document.createElement('option');
        opt.value = option[displayProperty];
        opt.textContent = option[displayProperty];
        select.appendChild(opt);
    });
}

async function fetchData(page) {
    const deviceType = document.getElementById('deviceType').value;
    const location = document.getElementById('location').value;
    const sortBy = document.getElementById('sortBy').value;
    const sortDirection = document.getElementById('sortDirection').value;

    let url = BaseUrl +`/api/devices?PageNumber=${page}&PageSize=${itemsPerPage}`;
    if (deviceType) url += `&DeviceType=${deviceType}`;
    if (location) url += `&Location=${location}`;
    if (sortBy) url += `&SortBy=${sortBy}`;
    if (sortDirection) url += `&SortDirection=${sortDirection}`;

    try {
        document.getElementById('loadingSpinner').style.display = 'flex';
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Authorization': Author, 
                'Content-Type': 'application/json'
            }
        });
        const data = await response.json();
        displayData(data.items);
        setupPagination(data.totalPages);
    } catch (error) {
        console.error('Error fetching data:', error);
    } finally {
        document.getElementById('loadingSpinner').style.display = 'none';
    }
}

function displayData(items) {
    const tbody = document.querySelector('#devicesTable tbody');
    tbody.innerHTML = ''; // Xóa nội dung cũ

    items.forEach((item, index) => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${index + 1 + (currentPage - 1) * itemsPerPage}</td>
            <td>${item.deviceName}</td>
            <td>${item.deviceType}</td>
            <td>${item.description}</td>
            <td>${item.size}</td>
            <td>${item.resolution}</td>
            <td>${new Date(item.createdAt).toLocaleDateString()}</td>
            <td>${item.status}</td>
            <td><button class="btn btn-info" onclick="showDetails(${item.id})">Details</button></td>
        `;
        tbody.appendChild(row);
    });
}

function setupPagination(totalPages) {
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = ''; // Xóa các nút phân trang cũ

    for (let i = 1; i <= totalPages; i++) {
        const li = document.createElement('li');
        li.classList.add('page-item');
        if (i === currentPage) {
            li.classList.add('active');
        }
        li.innerHTML = `<a class="page-link" href="#">${i}</a>`;
        li.addEventListener('click', (e) => {
            e.preventDefault();
            currentPage = i;
            fetchData(currentPage);
        });
        pagination.appendChild(li);
    }
}
    async function showDetails(id) {
    try {
        const response = await fetch(BaseUrl +`/api/devices/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': Author, 
                'Content-Type': 'application/json'
            }
        });
        const device = await response.json();
        displayDeviceDetails(device);
    } catch (error) {
        console.error('Error fetching device details:', error);
    }
}

function displayDeviceDetails(device) {
    const modalBody = document.querySelector('#detailModal .modal-body');
    modalBody.innerHTML = `
        <p><strong>Device Name:</strong> ${device.deviceName}</p>
                
        <h5>Daily Availability:</h5>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Total Available Minutes</th>
                </tr>
            </thead>
            <tbody>
                ${device.deviceDailyDtos.map(daily => `
                    <tr>
                        <td>${daily.dateTime}</td>
                        <td>${daily.totalAvailableMinutes}</td>
                    </tr>
                `).join('')}
            </tbody>
        </table>
               
    `;
    $('#detailModal').modal('show');
}


document.getElementById('searchButton').addEventListener('click', () => {
    currentPage = 1;
    fetchData(currentPage);
});

// Gọi hàm fetchOptions khi trang được tải
window.onload = () => {
    fetchOptions();
    fetchData(currentPage);
};