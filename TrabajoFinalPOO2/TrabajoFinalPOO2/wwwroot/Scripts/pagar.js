var hoy = new Date();
var fecha = hoy.getDate() + '-' + (hoy.getMonth() + 1) + '-' + hoy.getFullYear();
var elemento = document.getElementById("fecha");
elemento.innerHTML = fecha;

const exampleModal = document.getElementById('exampleModal')
if (exampleModal) {
    exampleModal.addEventListener('show.bs.modal', event => {
        const button = event.relatedTarget
        const recipient = button.getAttribute('data-bs-whatever')

        const modalTitle = exampleModal.querySelector('.modal-title')
        const modalBodyInput = exampleModal.querySelector('.modal-body input')

        modalTitle.textContent = `Ingrese con cuanto va pagar - ${recipient}`
        modalBodyInput.value = recipient
    })
}

let tbodys = document.getElementById("tbody");
let elementosFila = tbodys.getElementsByTagName("td");
var real = elementosFila.length - 1;

if (real > 0) {
    var a = (elementosFila[3].innerText).replace("S/", "");
    var e = a.replace(".00", "");
    var o = Number(e);
    var igv = o * 0.18;
    var total = o + igv;
    document.getElementById("total").innerHTML = "S/." + total.toFixed(2);
    document.getElementById("IGV").innerHTML = "S/." + igv.toFixed(2);
    document.getElementById("subtotal").innerHTML = "S/." + o.toFixed(2);
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            var vuelto = value - total;
            if (value < total) {
                document.getElementById("myInput").style.border = "3px solid red";
                document.getElementById("vuelto").innerHTML = "";
            } else {
                document.getElementById("myInput").style.border = "3px solid green";
                document.getElementById("vuelto").innerHTML = "El vuelto es de: S/." + vuelto.toFixed(2);            }
        });
    });

    var a2 = (elementosFila[7].innerText).replace("S/", "");
    var e2 = a2.replace(".00", "");
    var o2 = Number(e2);
    var suma1 = o + o2;
    var igv2 = suma1 * 0.18;
    var total2 = suma1 + igv2;
    document.getElementById("total").innerHTML = "S/." + total2.toFixed(2);
    document.getElementById("IGV").innerHTML = "S/." + igv2.toFixed(2);
    document.getElementById("subtotal").innerHTML = "S/." + suma1.toFixed(2);
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            var vuelto = value - total2;
            if (value < total2) {
                document.getElementById("myInput").style.border = "3px solid red";
                document.getElementById("vuelto").innerHTML = "";
            } else {
                document.getElementById("myInput").style.border = "3px solid green";
                document.getElementById("vuelto").innerHTML = "El vuelto es de: S/." + vuelto.toFixed(2);            }
        });
    });

    var a3 = (elementosFila[11].innerText).replace("S/", "");
    var e3 = a3.replace(".00", "");
    var o3 = Number(e3);
    var suma2 = o + o2 + o3;
    var igv3 = suma2 * 0.18;
    var total3 = suma2 + igv3;
    document.getElementById("total").innerHTML = "S/." + total3.toFixed(2);
    document.getElementById("IGV").innerHTML = "S/." + igv3.toFixed(2);
    document.getElementById("subtotal").innerHTML = "S/." + suma2.toFixed(2);
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            var vuelto = value - total3;
            if (value < total3) {
                document.getElementById("myInput").style.border = "3px solid red";
                document.getElementById("vuelto").innerHTML = "";
            } else {
                document.getElementById("myInput").style.border = "3px solid green";
                document.getElementById("vuelto").innerHTML = "El vuelto es de: S/." + vuelto.toFixed(2);            }
        });
    });

    var a4 = (elementosFila[15].innerText).replace("S/", "");
    var e4 = a4.replace(".00", "");
    var o4 = Number(e4);
    var suma3 = o + o2 + o3 + o4;
    var igv4 = suma3 * 0.18;
    var total4 = suma3 + igv4;
    document.getElementById("total").innerHTML = "S/." + total4.toFixed(2);
    document.getElementById("IGV").innerHTML = "S/." + igv4.toFixed(2);
    document.getElementById("subtotal").innerHTML = "S/." + suma3.toFixed(2);
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            var vuelto = value - total4;
            if (value < total4) {
                document.getElementById("myInput").style.border = "3px solid red";
                document.getElementById("vuelto").innerHTML = "";
            } else {
                document.getElementById("myInput").style.border = "3px solid green";
                document.getElementById("vuelto").innerHTML = "El vuelto es de: S/." + vuelto.toFixed(2);
            }
        });
    });

    var a5 = (elementosFila[19].innerText).replace("S/", "");
    var e5 = a5.replace(".00", "");
    var o5 = Number(e5);
    var total_precio = o + o2 + o3 + o4 + o5;
    var igv5 = total_precio * 0.18;
    var total5 = total_precio + igv5;
    document.getElementById("total").innerHTML = "S/." + total5.toFixed(2);
    document.getElementById("IGV").innerHTML = "S/." + igv5.toFixed(2);
    document.getElementById("subtotal").innerHTML = "S/." + total_precio.toFixed(2);
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            var vuelto = value - total5;
            if (value < total5) {
                document.getElementById("myInput").style.border = "3px solid red";
                document.getElementById("vuelto").innerHTML = "";
            } else {
                document.getElementById("vuelto").innerHTML = "El vuelto es de: S/." + vuelto.toFixed(2);
                document.getElementById("myInput").style.border = "3px solid green";
            }
        });
    });
} else {
    document.getElementById("pagar").style.display = "none";
}

function redireccionar() {
    if (document.getElementById("myInput").value == "") {
        console.log("Input Vacio");
    } else {
        Swal.fire(
            'Compra realizada',
            '',
            'success'
        )
        setTimeout(function () {
            var url = "http://enriquerenzo-001-site1.atempurl.com/TemporalVenta/VaciarLista";
            window.location.href = url; 
        }, 2000);
    }
}