(() => {
    'use strict'
    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            } else {
                swal("Mensaje Enviado", "Gracias por comunicarse con nosotros.", "success");
            }

            form.classList.add('was-validated')
        }, false)
    })
})()