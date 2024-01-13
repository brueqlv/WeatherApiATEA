document.addEventListener('DOMContentLoaded', function () {
    var ctx = document.getElementById('myChart').getContext('2d');

    var windSpeeds = chartData.windSpeeds;
    var temperatures = chartData.temperatures;
    var countries = chartData.countries;
    var cities = chartData.cities; var timeStamps = chartData.timeStamps.map(function (timestamp) {
        return new Date(timestamp);
    });

    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: timeStamps,
            datasets: [{
                label: 'Temperature (°C)',
                yAxisID: 'temperature',
                borderColor: 'rgba(255, 99, 132, 1)',
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                data: temperatures
            }, {
                label: 'Wind Speed (m/s)',
                yAxisID: 'windSpeed',
                borderColor: 'rgba(54, 162, 235, 1)',
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                data: windSpeeds
            }]
        },
        options: {
            scales: {
                x: {
                    type: 'time',
                    time: {
                        unit: 'minute',
                        parser: 'moment',
                        tooltipFormat: 'YYYY-MM-DD HH:mm:ss',
                        displayFormats: {
                            hour: 'YYYY-MM-DD HH:mm:ss'
                        }
                    },
                    title: {
                        display: true,
                        text: 'Time'
                    }
                },
                y: {
                    temperature: {
                        type: 'linear',
                        position: 'left',
                        title: {
                            display: true,
                            text: 'Temperature (°C)'
                        }
                    },
                    windSpeed: {
                        type: 'linear',
                        position: 'right',
                        title: {
                            display: true,
                            text: 'Wind Speed (m/s)'
                        }
                    }
                }
            },
            plugins: {
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            var label = context.dataset.label || '';
                            if (label) {
                                label += ': ';
                            }
                            label += context.parsed.y + ' ';

                            if (context.dataset.label === 'Temperature (°C)') {
                                label += '°C';
                            } else {
                                label += 'm/s';
                            }

                            var timeAdded = new Date(context.parsed.x);
                            var country = countries[context.dataIndex];
                            var city = cities[context.dataIndex];

                            label += '\nCountry: ' + country;
                            label += '\nCity: ' + city;
                            label += '\nTime Added: ' + timeAdded.toLocaleString();

                            return label;
                        }
                    }
                }
            }
        }
    });
});