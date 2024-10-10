# Project 2-1 (Unity ML-Agents Fork)

This repository is a **fork** of the original [Unity ML-Agents Toolkit](https://github.com/Unity-Technologies/ml-agents) and has been adapted specifically for **Project 2-1**. The project centers around the **soccer game environment**, and it is being extended with custom sensors, reward systems, and training modifications.

## Summary

The goal of this fork is to enhance and customize the Unity ML-Agents soccer environment for the BCS2720 course project. We focus on applying and analyzing Deep Reinforcement Learning (DRL) techniques to improve agent performance in a multi-agent soccer game simulation. The project provides hands-on experience with Unity, the ML-Agents toolkit, and reinforcement learning in-game environments.

### Key Modifications

- **Custom Sensors**: A new sensor implementation for the soccer environment to improve agent perception.
- **Modified Reward System**: Adjusted rewards and penalties, including punishments for hitting walls.
- **Training Modifications**: Optimized hyperparameters and network structure to improve agent training performance, such as increasing learning rate and hidden units.
- **Soccer Environment Tweaks**: Adjusted ball mass and agent speed to create a more challenging and realistic gameplay environment.

## Current Features

- **Unity Environment**: The soccer game environment serves as the primary scenario for training agents.
- **Custom Sensors**: Forward-only ray-casts and memory of past observations to enhance decision-making for soccer agents.
- **Reinforcement Learning**: Uses the Proximal Policy Optimization (PPO) and MA-POCA algorithms for training multi-agent scenarios.
- **Collaborative Development**: The project leverages GitHub for version control and collaborative development among team members.

## Future Plans

We aim to continue refining the soccer environment by:
- **Performance Optimization**: Further tuning the reward system and hyperparameters for optimal learning efficiency.
- **Agent Behavior Analysis**: Analyzing agent behaviors in different game scenarios to enhance strategy development.
- **New Features**: Exploring the integration of additional sensors and alternative learning algorithms to diversify training outcomes.

## Getting Started

### Prerequisites

- **Unity 2020.1 or later**: Required to run the soccer environment simulations.
- **Python 3.10+**: Required for running the ML-Agents Python API.
- **ML-Agents Toolkit**: Install via the Python package manager:

  ```bash
  pip install mlagents
  ```

### Running the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/Amir-Mohseni/AIML12
   ```
2. Open the Unity project in your Unity Editor.
3. Navigate to the soccer environment scene and press **Play** to start the simulation.
4. Use the provided Python scripts to run training sessions:

   ```bash
   mlagents-learn config/trainer_config.yaml --run-id=<your_run_id>
   ```

### Contributing

We welcome contributions to improve the project. Please feel free to submit issues or pull requests, and review our [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE.md) file for details.
