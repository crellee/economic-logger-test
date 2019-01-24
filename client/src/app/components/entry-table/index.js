import React, { Component } from 'react';
import moment from 'moment'

export default class EntryTable extends Component {
    render() {
        const { entries } = this.props
        return (
            <React.Fragment>
                {entries.length !== 0 ?
                    <div>
                        <table className="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Hours spent</th>
                                    <th scope="col">Registered</th>
                                </tr>
                            </thead>
                            <tbody>
                                {entries.map((entry, index) => (
                                    <tr key={index}>
                                        <td>{entry.Id}</td>
                                        <td>{entry.TimeSpent}</td>
                                        <td>{moment(entry.Date).local().format('DD-MM-YYYY | h:mm:ss a')}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                        <p>
                            Total hours spent: <b>{entries.sum("TimeSpent")}</b>
                        </p>
                    </div>
                    :
                    <div>
                        No entries have been added to this project.
                    </div>
                }
            </React.Fragment>
        )
    }
}

Array.prototype.sum = function (prop) {
    return this.reduce((a, b) => +a + +b[prop], 0);
}