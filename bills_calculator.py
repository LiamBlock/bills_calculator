from flask import Flask, render_template, request

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
    if request.method == 'POST':
        income1 = float(request.form['income1'])
        income2 = float(request.form['income2'])
        rent = float(request.form['rent'])
        electricity = float(request.form['electricity'])
        broadband = float(request.form['broadband'])
        water = float(request.form['water'])
        council_tax = float(request.form['council_tax'])

        total_income = income1 + income2
        person1_split = (income1 / total_income) * 100
        person2_split = (income2 / total_income) * 100
        total_bills = rent + electricity + broadband + water + council_tax
        person1_pays = (person1_split / 100) * total_bills
        person2_pays = (person2_split / 100) * total_bills

        result = f"Total cost of bills: {total_bills}\n" \
                 f"Person 1 made {round(person1_split, 2)} of income\n" \
                 f"Person 2 made {round(person2_split, 2)} of income\n" \
                 f"{round(person1_split, 2)}% of {total_bills} is {round(person1_pays, 2)}\n" \
                 f"{round(person2_split, 2)}% of {total_bills} is {round(person2_pays, 2)}\n" \
                 f"Person 1 pays {round(person1_pays, 2)}\n" \
                 f"Person 2 pays {round(person2_pays, 2)}\n"

        return render_template('index.html', result=result)

    return render_template('index.html', result="")

if __name__ == '__main__':
    app.run(host="localhost", port=8000)