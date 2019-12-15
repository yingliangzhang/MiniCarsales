import React from 'react'
import CarImage from '../../images/car_placeholder.png'
import {
    Card,
    CardImg,
    CardText,
    CardBody,
    CardTitle,
    CardSubtitle
} from 'reactstrap'

const CarCard = ({ car }) => (
    <Card className="mt-2">
        <CardImg top src={CarImage} alt="Car" />
        <CardBody>
            <CardTitle>{car.make} {car.model}</CardTitle>
            <CardSubtitle>{car.bodyType} {car.engine}</CardSubtitle>
            <CardText>Doors: {car.numberOfDoors}</CardText>
        </CardBody>
    </Card>
)

export default CarCard