function RegisterUser() {
    let firstName = document.getElementById('fName').value;
    let lastName = document.getElementById('lName').value;
    let UserId = document.getElementById('uid').value;
    let Password = document.getElementById('password').value;
    let Contact = document.getElementById('contact').value;
    let emailId = document.getElementById('emailid').value;
    fetch('https://localhost:44307/api/auth/register', {
        method: 'POST',
        body: JSON.stringify({ firstName, lastName, UserId, Password, Contact, emailId }),
        headers: {
            'Content-Type': 'application/json'            
        }
    }).then(res => {
        alert("User Registered Successfully!");   
        location.href = "login.html";      
    });
}