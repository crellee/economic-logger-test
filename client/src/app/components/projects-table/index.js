import React, { Component } from 'react';

export default class ProjectsTable extends Component {
	render() {
		const { projects, get } = this.props
		return (
			<table className="table table-hover">
				<thead className="thead-dark">
					<tr>
						<th scope="col">#</th>
						<th scope="col">Project Name</th>
					</tr>
				</thead>
				<tbody>
					{projects.map((project, index) => (
						<tr key={index} className="pointer" onClick={() => get(project.Id)}>
							<td>{project.Id}</td>
							<td>{project.Name}</td>
						</tr>
					))}
				</tbody>
			</table>
		);
	}
}