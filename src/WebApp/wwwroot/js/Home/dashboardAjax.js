$(document).ready(function () {

    //Atas por Ano
    $.ajax({
        type: 'GET',
        async: true,
        url: '/Ata/GetAtasGraphicsByYears/',
        success: function (response) {
            const labels = [];
            const datas = [];
            for (var year = 0; year < response.length; year++) {
                labels[year] = response[year].year
                datas[year] = response[year].count
            }
            const data = {
                labels: labels,
                datasets: [{
                    label: 'Atas por Ano',
                    data: datas,
                    backgroundColor: 'rgba(19, 41, 61, 1)',
                    borderColor: 'rgba(36, 123, 160, 1)',
                    borderWidth: 1
                }]
            };

            const config = {
                type: 'bar',
                data: data,
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                },
            };

            const myChartAtaAno = new Chart(
                document.getElementById('ChartAtasYears'),
                config
            );
        }
    })

    //Atas por mês
    $.ajax({
        type: 'GET',
        async: true,
        url: '/Ata/GetAtasGraphicsByMonths/',
        success: function (response) {
            const labels = [];
            const datas = [];
            const dataAtual = new Date();
            const anoAtual = dataAtual.getFullYear();

            for (var month = 0; month < response.length; month++) {
                labels[month] = response[month].month
                datas[month] = response[month].count
            }
            const data = {
                labels: labels,
                datasets: [{
                    label: `Atas por Mês - ${anoAtual}`,
                    data: datas,
                    backgroundColor: 'rgba(19, 41, 61, 1)',
                    borderColor: 'rgba(36, 123, 160, 1)',
                    borderWidth: 1
                }]
            };


            const config = {
                type: 'line',
                data: data,
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                },
            };

            const myChart = new Chart(
                document.getElementById('ChartAtasMonths'),
                config
            );
        }
    })
});      