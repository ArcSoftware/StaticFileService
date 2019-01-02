import React, { Component } from 'react';

export class StaticFile extends Component {
    displayName = StaticFile.name

    constructor(props) {
        super(props);
        this.state = { sounds: [], loading: true };

        fetch('api/StaticFile/PlayQuakeSound')
            .then(response => response.play);
    }

    static renderQuakeSound() {
        return (
        <button
        )}

    );
}

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
        : FetchData.renderQuakeSound();

        return (
            <div>
            <h1>Static Files</h1>
            {contents}
            </div>
    );
}
}