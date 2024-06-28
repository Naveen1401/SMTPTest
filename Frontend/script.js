const form = document.querySelector('form');

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    const formData = new FormData(form);

    const data = {
        toEmail: formData.get('toEmail'),
        subject: formData.get('subject'),
        body: formData.get('body'),
        fromEmail: formData.get('fromEmail'),
        smtpServer: formData.get('smtpServer'),
        port: parseInt(formData.get('port')),
        username: formData.get('username'),
        password: formData.get('password'),
        useSSl: formData.get('useSsl') === 'on'
    };

    try {
        const response = await fetch('http://localhost:5044/api/Mail/send', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Email sent successfully!');
        } else {
            alert('Failed to send email.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An error occurred while sending the email.');
    }
});