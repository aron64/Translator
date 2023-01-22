import React from 'react';
import ReactDOM from 'react-dom/client';

/*
 * Author: Aron L. Hertendi
 * React FrontEnd for querying phrases to translate
                     and to display the result
 
 * Notes for initial commit:
 * This file contains a single React Component that renders the input field, 
 * which reacts to changes within itself,
 * and renders the result,
 * based on the fetch's feedback (which does not work with the input data for now) 
 */

class Translator extends React.Component{
  constructor(props) {
    super(props);
    this.state = {value: '', result: '', error: null};
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(event) {
      this.setState({
        value : event.target.value,
        error: null,
        result: "Loading...",
      });
      fetch("https://localhost:5001/Phrase")
      .then(res => res.json())
      .then(
        (result) => { this.setState({value: event.target.value, result: result.hungarian, error: null}); },
        (error) => { this.setState({value: event.target.value, result: '', error}); }
      );
    }
  
  render(){
    var result = this.state.error
                  ?`HTTP ERROR ${this.state.error}`
                  :(this.state.result?this.state.result:"The phrase could not be found");

    return (
        <div>
          <form onSubmit={this.handleSubmit}>
            <label>
              Text to translate:&nbsp;&nbsp;&nbsp;&nbsp;
              <input type="text" value={this.state.value} onChange={this.handleChange} />
            </label>
          </form>
          <div className = "translate-result">
            {result}
          </div>
        </div>
      );
  }
}

// ========================================

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<Translator />);
