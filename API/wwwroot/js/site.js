//------- Begin Get externals employees -----------//

function getExternalEmployees() {
    fetch('EmployeeExternal')
        .then(response => response.json())
        .then(data => renderTable(data, getBodyTableExternalEmployee()))
        .catch(error => console.error("Error" + error.message));
}

//------- End Get externals employees -----------//


//------- Begin Create employee -----------//

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


//------- End Create employee -----------//

//------- Begin Get employees -----------//

function getEmployees() {
    idEmployee = getIdEmployee();

    if (idEmployee)
        getEmployee();
    else
        getEmployeesAll();
}


function getIdEmployee() {
    const idEmployee = document.getElementById('idEmployee');

    return idEmployee.value;
}

function getEmployee() {
    const id = getIdEmployee();

    const route = `Employee/${id}/employee`;

    fetch(route)
            .then(response => response.json())
        .then(data => renderTable([data], getBodyTableEmployee()))
            .then(cleanInputIdEmpoyee())
        .catch(error => alert(`Employee with id ${id} not exist`));
}

function getEmployeesAll() {
    const route = 'Employee';

    fetch(route)
        .then(response => response.json())
        .then(data => renderTable(data, getBodyTableEmployee()))
        .catch(error => console.error("Error" + error.message));
}

function cleanInputIdEmpoyee() {
    const idEmployee = document.getElementById('idEmployee');

    idEmployee.value = '';
}

function getBodyTableExternalEmployee() {
    return document.getElementById('table-detail-external-employee');
}

function getBodyTableEmployee() {
    return document.getElementById('table-detail-employee');
}

function renderTable(employees, bodyTable) {

    if (bodyTable.rows.length > 0) {
        for (let i = 0; i < employees.length; i++) {
            bodyTable.innerHTML = '';
        }
    }

    for (const item of employees) {
        let trElement = document.createElement('tr');

        let idTdElement = document.createElement('td');
        idTdElement.innerHTML = item.EmployeeId;
        trElement.appendChild(idTdElement);

        let nameTdElement = document.createElement('td');
        nameTdElement.innerHTML = item.Name;
        trElement.appendChild(nameTdElement);

        let lastNameTdElement = document.createElement('td');
        lastNameTdElement.innerHTML = item.LastName;
        trElement.appendChild(lastNameTdElement);

        let typeContractTdElement = document.createElement('td');
        typeContractTdElement.innerHTML = item.TypeContract;
        trElement.appendChild(typeContractTdElement);

        let SalaryTdElement = document.createElement('td');
        SalaryTdElement.innerHTML = ` ${item.Salary.Amount} ${item.Salary.Currency}`;
        trElement.appendChild(SalaryTdElement);

        let annualSalaryTdElement = document.createElement('td');
        annualSalaryTdElement.innerHTML = ` ${item.AnnualSalary.Amount} ${item.AnnualSalary.Currency}`;
        trElement.appendChild(annualSalaryTdElement);

        let roleNameTdElement = document.createElement('td');
        roleNameTdElement.innerHTML = item.RoleName;
        trElement.appendChild(roleNameTdElement);

        let roleDescriptrionTdElement = document.createElement('td');
        roleDescriptrionTdElement.innerHTML = item.RoleDescriptrion;
        trElement.appendChild(roleDescriptrionTdElement);

        bodyTable.appendChild(trElement);
    }

}
//------- End Get employees -----------//