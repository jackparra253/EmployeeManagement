console.log('Hi');

function getExternalEmployees() {
    const uri = 'EmployeeExternal';

    fetch(`${uri}`)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(err => console.error("Error" + error.message));
}
