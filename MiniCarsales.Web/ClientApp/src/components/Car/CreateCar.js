import React from 'react'
import { connect } from 'react-redux'
import history from '../../history'
import { withRouter } from 'react-router-dom'
import { createCar } from '../../actions/car/createCar'
import { fetchBodyTypes } from '../../actions/car/fetchBodyTypes'
import {
    Spinner,
    Form,
    FormGroup,
    Label,
    Input,
    Button,
    FormFeedback,
} from 'reactstrap'

class CreateCar extends React.Component {
    state = {
		newCar: {
            make: "",
            model: "",
            engine: "",
            numberOfDoors: 4,
            numberOfWheels: 4,
            bodyType: "",
            errors: {
                make: "",
                model: "",
                engine: "",
                numberOfDoors: "",
                numberOfWheels: "",
                bodyType: "",
            }
        },
    }
    
    componentDidMount() {
        const { fetchBodyTypes } = this.props
        fetchBodyTypes()
    }

    handleOnChange = (event) => {
        const { name, value } = event.target

        this.setState({
            newCar: {
                ...this.state.newCar,
              [name]: value
            }
        }, () => {
            this.validateState(name)
        })
    }

    validateState(name) {
        const newCar = this.state.newCar
        let errors = this.state.newCar.errors

        switch (name) {
            case 'make' :
                errors.make = newCar.make.length < 1 ? 'Make can not be empty' : ''
                break
            case 'model' :
                errors.model = newCar.model.length < 1 ? 'Model can not be empty' : ''
                break
            case 'engine' :
                errors.engine = newCar.engine.length < 1 ? 'Engine can not be empty' : ''
                break
            case 'numberOfDoors' :
                errors.numberOfDoors = newCar.numberOfDoors < 1 || newCar.numberOfDoors > 10 ? 'Number of doors must be between 1 and 10' : ''
                break
            case 'numberOfWheels' :
                errors.numberOfWheels = newCar.numberOfWheels < 2 || newCar.numberOfWheels > 8 ? 'Number of wheels must be between 1 and 10' : ''
                break
            case 'bodyType' :
                errors.bodyType = newCar.bodyType < 1 ? 'Must select a body type' : ''
                break
        }

        this.setState({
            newCar: {
                ...this.state.newCar,
                errors : errors
            }
        })  
    }

    handleSubmit = (event) => {
        event.preventDefault()

        if (this.validateForm()) {
            const { createCar } = this.props
            const created = createCar(this.state.newCar)
            created.then(() => history.push("/"))
        }
    }

    validateForm() {
        const newCar = this.state.newCar

        for (var field in newCar) {
            if (newCar.hasOwnProperty(field)) {
                this.validateState(field)
            }
        }

        const errors = this.state.newCar.errors
        let valid = true;

        Object.values(errors).forEach((error) => {
            if (error.length > 0) {
                valid = false
            }
        })

        return valid
    }

    render() {
        const { fetchingBodyTypes, bodyTypes, creatingCar } = this.props
        const { newCar } = this.state

        if (fetchingBodyTypes || creatingCar) {
            return <Spinner type="grow" color="primary" />    
        } else {
            return <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <h1 className="text-center">Create Car</h1>
                    </div>
                </div>

                <div className="row justify-content-md-center">
                    <div className="col-md-8">
                        <Form onSubmit={this.handleSubmit}>
                            <FormGroup>
                                <Label for="make">Make</Label>
                                <Input invalid={newCar.errors.make.length > 0} type="text" name="make" id="make" placeholder="Enter make of the car" value={newCar.make} onChange={this.handleOnChange}/>
                                { newCar.errors.make.length > 0 && <FormFeedback>{newCar.errors.make}</FormFeedback> }
                            </FormGroup>
                            <FormGroup>
                                <Label for="model">Model</Label>
                                <Input invalid={newCar.errors.model.length > 0} type="text" name="model" id="model" placeholder="Enter model of the car" value={newCar.model} onChange={this.handleOnChange}/>
                                { newCar.errors.model.length > 0 && <FormFeedback>{newCar.errors.model}</FormFeedback> }
                            </FormGroup>
                            <FormGroup>
                                <Label for="engine">Engine</Label>
                                <Input invalid={newCar.errors.engine.length > 0} type="text" name="engine" id="engine" placeholder="Enter engine type of the car" value={newCar.engine} onChange={this.handleOnChange}/>
                                { newCar.errors.engine.length > 0 && <FormFeedback>{newCar.errors.engine}</FormFeedback> }
                            </FormGroup>
                            <FormGroup>
                                <Label for="numberOfDoors">Number of Doors</Label>
                                <Input invalid={newCar.errors.numberOfDoors.length > 0} type="number" min="1" max="10" name="numberOfDoors" id="numberOfDoors" placeholder="Enter number of doors of the car" value={newCar.numberOfDoors} onChange={this.handleOnChange}/>
                                { newCar.errors.numberOfDoors.length > 0 && <FormFeedback>{newCar.errors.numberOfDoors}</FormFeedback> }
                            </FormGroup>
                            <FormGroup>
                                <Label for="numberOfWheels">Number of Wheels</Label>
                                <Input invalid={newCar.errors.numberOfWheels.length > 0} type="number" min="2" max="8" name="numberOfWheels" id="numberOfWheels" placeholder="Enter number of wheels of the car" value={newCar.numberOfWheels} onChange={this.handleOnChange}/>
                                { newCar.errors.numberOfWheels.length > 0 && <FormFeedback>{newCar.errors.numberOfWheels}</FormFeedback> }
                            </FormGroup>
                            <FormGroup>
                                <Label for="bodyType">Body Type</Label>
                                <Input invalid={newCar.errors.bodyType.length > 0} type="select" name="bodyType" id="bodyType" value={newCar.bodyType} onChange={this.handleOnChange}>
                                    <option value="" disabled>Please select body type</option>
                                    {
                                        bodyTypes.map(bodyType => (
                                            <option value={bodyType} key={bodyType}>{bodyType}</option>
                                        ))
                                    }
                                </Input>
                                { newCar.errors.bodyType.length > 0 && <FormFeedback>{newCar.errors.bodyType}</FormFeedback> }
                            </FormGroup>
                            <Button color="primary">Submit</Button>
                        </Form>
                    </div>
                </div>
            </div>
        }
    }
}

const mapStateToProps = state => ({
    fetchingBodyTypes: state.car.fetchingBodyTypes,
    bodyTypes: state.car.bodyTypes,
})

const mapDispatchToProps = {
    createCar,
    fetchBodyTypes,
}

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps
)(CreateCar))