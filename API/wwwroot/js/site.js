function getExternalEmployees() {
    const route = 'EmployeeExternal';

    fetch(`${route}`)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error("Error" + error.message));
}


function save() {
    if (isHourlySalary()) 
        saveEmployeeHourlySalary();

    if (isMonthlySalary())
        saveEmployeMonthlySalary();
}

function isHourlySalary() {
    return getContract() == 1;
}

function isMonthlySalary() {
    return getContract() == 2;
}

function getContract() {
    const contracts = document.getElementById('contracts');

    return parseInt(contracts.options[contracts.selectedIndex].value);
}

function saveEmployeeHourlySalary() {
    const route = 'Employee/HourlySalary';
    const requestEmployeeHourlySalar = createRequestEmployee();
    
    requestSave(route, requestEmployeeHourlySalar);
}

function saveEmployeMonthlySalary() {
    const route = 'Employee/MonthlySalary';
    const requestEmployeeMonthlySalary = createRequestEmployee();

    requestSave(route, requestEmployeeMonthlySalary);
}

function requestSave(route, requestEmployee) {
    fetch(route, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestEmployee)
        }).then(response => response.json())
        .then(data => console.log(data))
        .then(cleanForm())
        .then(getEmployees())
        .catch(error => console.error('unable to add Employee', error));
}

function createRequestEmployee() {
    return {
        name: getName(),
        lastName: getLastName(),
        idRole: getIdRole(),
        amount: getAmount()
    }
}

function getName() {
    const name = document.getElementById('name');

    return name.value;
}

function getLastName() {
    const lastName = document.getElementById('lastName');

    return lastName.value;
}

function getIdRole() {
    const roles = document.getElementById('roles');

    return parseInt(roles.options[roles.selectedIndex].value);
}

function getAmount() {
    const amount = document.getElementById('amount');

    return parseInt(amount.value);
}

function limpiarFormulario() {
    const fechaIncial = document.getElementById('fechaInicial')
    const cantidadDias = document.getElementById('cantidadDias');
    const fechaFinal = document.getElementById('fechaFinal');
    const observaciones = document.getElementById('observaciones');

    fechaIncial.value = '';
    fechaFinal.innerText = '';
    cantidadDias.value = '';
    observaciones.value = '';
    alert("Se guardo la incapacidad");
}

function cleanForm() {
    const name = document.getElementById('name');
    const lastName = document.getElementById('lastName');
    const amount = document.getElementById('amount');

    name.value = '';
    lastName.value = '';
    amount.value = '';

    alert('Save employee.');
}


function getEmployees() {
    const route = 'Employee';

    fetch(route)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error("Error" + error.message));
}