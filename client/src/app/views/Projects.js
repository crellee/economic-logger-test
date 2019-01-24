import React, { Component } from 'react'
import ProjectsTable from '../components/projects-table'
import EntriesTable from '../components/entry-table'
import EntryForm from '../components/entry-form'
import projectsApi from '../api/projects'
class Projects extends Component {
	constructor() {
		super()
		this.state = {projects: [], project: {}, entryForm: false, searchText: ""}

		this.getProject = this.getProject.bind(this)
		this.formActive = this.formActive.bind(this)
		this.searchTextChange = this.searchTextChange.bind(this)
		this.keyDown = this.keyDown.bind(this)
		this.findProjects = this.findProjects.bind(this)
	}
	async componentDidMount() {
		const projects = await projectsApi.getAll()
		this.setState({projects})
	}

	async getProject(id) {
		const project = await projectsApi.get(id)
		this.setState({project})
	}

	formActive() {
		this.setState({entryForm: !this.state.entryForm})
	}

	searchTextChange(e) {
		e.preventDefault()
		this.setState({searchText: e.target.value})
	}
	
	keyDown(e) {
		if(e.keyCode == 13){
			this.findProjects()
		}
	}

	async findProjects() {
		const projects = await projectsApi.find(this.state.searchText)
		this.setState({projects})
	}

	render() {
		const { projects, project, entryForm, searchText } = this.state
		return (
			<React.Fragment>
				<div className="row">
					<div className="col-auto mr-auto">
					 	<button className="btn btn-primary" type="button" onClick={this.formActive}>
						 	{!entryForm ? 'Add entry' : 'Hide entry'}
						 </button>
						 <div>
							 {entryForm && 
							 	<EntryForm projects={projects} projectUpdated={this.getProject} />
							 }
						 </div>
					</div>

					<div className="col-auto">
					 	<div className="form-inline my-2 my-lg-0 float-right">
							<input 
								className="form-control mr-sm-2" 
								value={searchText} 
								onChange={this.searchTextChange} 
								placeholder="Search" 
								aria-label="Search" 
								onKeyDown={this.keyDown} />
                            <button className="btn btn-primary my-2 my-sm-0" type="button" onClick={this.findProjects}>Search</button>
                        </div>
					</div>
				</div>
				<div className="row">
					<div className="col-6">
                		<ProjectsTable projects={this.state.projects} get={this.getProject} />
					</div>
					<div className="col-6 mt-4">
						{!(Object.entries(project).length === 0 && project.constructor === Object) ? 
							<div className="">
								<h3>{project.Name}</h3>
								<EntriesTable entries={project.TimeLogs} />
							</div>
						: 
							<div>
								Click on a project
							</div>
						}
						
					</div>
				</div>
            </React.Fragment>
		);
	}
}

export default Projects;