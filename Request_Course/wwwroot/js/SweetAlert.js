
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

function myFunction() {
    event.preventDefault();
    Swal.fire({
        title: 'آیا از اطلاعات خود مطمئن هستید ',
        icon: 'question',
        imageWidth: 350,
        imageHeight: 300,
        showCloseButton: false,
        showCancelButton: true,
        focusConfirm: false,
        cancelButtonColor: '#d33',
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'تایید',
        cancelButtonText: 'رد',
    }).then(res => {
        if (res.isConfirmed) {
            document.getElementById("myForm").submit();
        } else {
            Swal.fire({
                title: 'عدم تایید',
                text: 'عدم ارسال اطلاعات',
                icon: 'error',
                confirmButtonText: 'اوکی',
                cancelButtonText: 'اوکی',
            })
        }
    });
}


}
