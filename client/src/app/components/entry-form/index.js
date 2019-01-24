import React, { Component } from 'react'
import entryApi from '../../api/entries'
export default class EntryForm extends Component {
    constructor() {
        super()
        this.state = {form: {}}
        this.onChange = this.onChange.bind(this)
        this.submit = this.submit.bind(this)
    }

    onChange = (e) => {
        const { target: { name, value }} = e
        
        this.setState({
            form: {
                ...this.state.form,
                [name]: value
            }
        })
    }

    getValue = (key) => {
        const stateValue = this.state.form[key]
        return stateValue || ''
    }

    async submit(e) {
        e.preventDefault()
        const { form } = this.state
        if(form.TimeSpent && form.ProjectId) {
            await entryApi.create(form)
            await this.props.projectUpdated(form.ProjectId)
            return
        }
    }

    render() {
        const { projects } = this.props
        console.log(this.state.form)
        return(
            <form onSubmit={this.submit}>
                <div className="form-group">
                    <label>Time Spent</label>
                    <input 
                        type="number" 
                        className="form-control" 
                        placeholder="Hours spent" 
                        name="TimeSpent" 
                        value={this.getValue('TimeSpent')} 
                        onChange={this.onChange} />
                </div>
                <div className="form-group">
                    <label>Choose a project</label>
                    <select className="form-control" name="ProjectId" defaultValue="" onChange={this.onChange}>
                    <option value="" disabled>Choose...</option>
                        {projects.map((project, index) => (
                            <option key={index} value={project.Id}>{project.Name}</option>
                        ))}
                    </select>
                </div>
                <button className="btn btn-success">Save entry</button>
            </form>
        )
    }
}