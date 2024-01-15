document.addEventListener('DOMContentLoaded', function () {
    var ctx = document.getElementById('myChart').getContext('2d');

    var cityLabels = chartData.cityLabels;
    var windSpeeds = chartData.windSpeeds;
    var countries = chartData.countries;

    var timesAdded = chartData.timesAdded.map(function (timesAdded) {
        return new Date(timesAdded);
    });

    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: cityLabels,
            datasets: [{
                label: 'WindSpeed',
                data: windSpeeds,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                x: {
                    beginAtZero: true
                },
                y: {
                    beginAtZero: true
                }
            },
            plugins: {
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            var index = context.dataIndex;
                            var label = context.dataset.label || '';

                            if (label) {
                                label += ': ';
                            }
                            label += context.parsed.y + ' m/s, Country: ' + countries[index] + ', Last Updated: ' + timesAdded[index];
                            return label;
                        }
                    }
                }
            },
            onClick: function (event, elements) {
                if (elements.length > 0) {
                    var clickedIndex = elements[0].index;
                    var clickedCity = cityLabels[clickedIndex];
                    window.location.href = 'https://localhost:7079/gettwohourtrend/' + clickedCity;
                }
            }

        }
    });
});