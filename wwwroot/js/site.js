$("#menu-toggle").click(function (e) {
	e.preventDefault();
	$("#wrapper").toggleClass("toggled");
});

$(document).ready(function () {
    $('#dtBasicExample').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ de total de registros",
            "zeroRecords": "Não foi encontrado",
            "info": "Página _PAGE_ de _PAGES_",
            "infoEmpty": "Sem registros",
            "search": "Buscar:",
            "infoFiltered": "(filtros para _MAX_ total de registros)",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Voltar"
            },
        }
    });

    $('.dataTables_length').addClass('bs-select');
});