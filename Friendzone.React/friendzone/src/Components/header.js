import * as React from 'react';
import './header.css';
const api_root = 'https://localhost:44339';


var options = {
    method: 'GET'//,
    //mode: 'no-cors'
};

function getData() {

    console.log(options);

    return fetch('https://friendzone.azurewebsites.net/api/Locations/country:1/Cities', options)
        .then(response => response.json())
        .then( (res) => {
            console.log(res);
        });

    // return rp(options)
    // .then(res => res.json());
}


export class Header extends React.Component {

	constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount() {
        getData();
    }

	
	render() {
		return (
			<div
				id={ this.props.containerId }
				className={ 'TVChartContainer' }
			/>
        );
    }


}