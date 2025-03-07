
 
//let customAlert = {
//    confirmDelete: function (callback) {
//        Swal.fire({
//            title: 'Are you sure?',
//            text: "You won't be able to revert this!",
//            icon: 'warning',
//            showCancelButton: true,
//            confirmButtonColor: '#3085d6',
//            cancelButtonColor: '#d33',
//            confirmButtonText: 'Yes, delete it!'
//        }).then((result) => {
//            if (result.isConfirmed) {
//                callback(result);
//            }
//        })
//    },
//    success: function (message,title) {
//        Swal.fire({
//            position: 'top-end',
//            icon: 'success',
//            title: message,
//            text: title,
//            showConfirmButton: false,
//            timer: 1500
//        });
//    },
//    error: function (message,title) {
//        Swal.fire({
//            position: 'top-end',
//            icon: 'error',
//            title: title,
//            text: message,
//            showConfirmButton: false,
//            timer: 1500
//        });
//    }

//}
// wwwroot/js/alerts.js
const customAlert = {
    success: (message, title) => {
        Swal.fire({
            icon: 'success',
            title: title,
            text: message
        });
    },

    error: (message, title) => {
        Swal.fire({
            icon: 'error',
            title: title,
            text: message
        });
    },

    confirmDelete: (callback) => {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                callback();
            }
        });
    }
};