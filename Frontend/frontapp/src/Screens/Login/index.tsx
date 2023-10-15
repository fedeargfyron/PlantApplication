import { Button, Card, CardBody, CardHeader, Divider, Input } from "@nextui-org/react"
import axios from "axios";
import { useEffect } from "react";
import { useForm } from 'react-hook-form'
import { useNavigate } from "react-router-dom";

function Login() {
  const { register, handleSubmit } = useForm();
  const token = localStorage.getItem('token');

  const navigate = useNavigate();
  useEffect(() => {
    token && navigate("/")
  }, [token, navigate])

  const login = (data) => {
    localStorage.setItem('token', data);
    navigate("/");
  }

  const onSubmit = (e) => {
    axios.post('https://localhost:44374/security', 
      {
        email: e.email,
        password: e.password
      })
      .then(res => login(res.data))
      .catch(err => console.log(err));
  }

  return (
    <div className="flex items-center justify-center h-screen bg-softwhite">
      <form className="w-full max-w-md" onSubmit={handleSubmit(onSubmit)}>
        <Card>
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Log In</h1>
          </CardHeader>
          <Divider />
          <CardBody className="flex items-center justify-center">
            <Input label="Email" className="p-2 text-2xl" {...register("email", { required: true })}/>
            <Input type="password" label="Password" className="p-2 text-2xl" {...register("password", { required: true })} />
            <Button type="submit" color="success" className="p-5 font-bold text-white">Sign In</Button>
          </CardBody>
        </Card>
      </form>
    </div>
  )
}

export default Login