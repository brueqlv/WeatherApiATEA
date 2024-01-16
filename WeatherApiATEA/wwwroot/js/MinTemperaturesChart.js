document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('myChart').getContext('2d');

    const cityLabels = chartData.cityLabels;
    const temperatures = chartData.temperatures;
    const countries = chartData.countries;

    const timesAdded = chartData.timesAdded.map(function (timesAdded) {
        return new Date(timesAdded);
    });

    const myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: cityLabels,
            datasets: [{
                label: 'Temperature',
                data: temperatures,
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
                            const index = context.dataIndex;
                            let label = context.dataset.label || '';

                            if (label) {
                                label += ': ';
                            }
                            label += context.parsed.y + ' °C, Country: ' + countries[index] + ', Last Updated: ' + timesAdded[index];
                            return label;
                        }
                    }
                }
            },
            onClick: function (event, elements) {
                if (elements.length > 0) {
                    const clickedIndex = elements[0].index;
                    const clickedCity = cityLabels[clickedIndex];
                    window.location.href = 'https://localhost:7079/gettwohourtrend/' + clickedCity;
                }
            }
        }
    });
});